using Game08.Sdk.GlslLanguageServices.LanguageModels.Ast;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.Builder.AstAnalysis
{
    public static class AstHelper
    {
        public static bool TypeSpecifiersAreEquivalent(TypeSpecifier typeSpecifier1, TypeSpecifier typeSpecifier2, bool compareQualifier = false)
        {
            if (typeSpecifier1 == null && typeSpecifier2 == null)
            {
                return true;
            }

            if (typeSpecifier1 == null || typeSpecifier2 == null)
            {
                return false;
            }

            if (typeSpecifier1 is TypeNameSpecifier)
            {
                if (!(typeSpecifier2 is TypeNameSpecifier))
                {
                    return false;
                }

                return TypeNameSpecifiersAreEquivalent((TypeNameSpecifier)typeSpecifier1, (TypeNameSpecifier)typeSpecifier2, compareQualifier);
            }

            if (typeSpecifier1 is StructTypeSpecifier)
            {
                if (!(typeSpecifier2 is StructTypeSpecifier))
                {
                    return false;
                }

                return StructTypeSpecifiersAreEquivalent((StructTypeSpecifier)typeSpecifier1, (StructTypeSpecifier)typeSpecifier2, compareQualifier);
            }

            throw new InvalidOperationException($"Unsupported type specifier type {typeSpecifier1.GetType()}.");
        }

        public static bool IdentifiersAreEquivalent(Identifier identifier1, Identifier identifier2)
        {
            return (string.IsNullOrEmpty(identifier1?.Name) && string.IsNullOrEmpty(identifier2?.Name))
                || identifier1?.Name == identifier2?.Name;
        }

        private static bool TypeNameSpecifiersAreEquivalent(TypeNameSpecifier typeSpecifier1, TypeNameSpecifier typeSpecifier2, bool compareQualifier = false)
        {
            return IdentifiersAreEquivalent(typeSpecifier1.Identifier, typeSpecifier2.Identifier)
                && (!compareQualifier || TypeQualifiersAreEquivalent(typeSpecifier1.Qualifier, typeSpecifier2.Qualifier));
        }

        public static bool ConstantExpressionValuesAreEquivalent(Expression expression1, Expression expression2)
        {
            if (expression1 == null && expression2 == null)
            {
                return true;
            }

            if (expression1 == null || expression2 == null)
            {
                return false;
            }

            if (expression1 is IntegerLiteral && expression2 is IntegerLiteral)
            {
                return IntegerLiteralsAreEquivalent((IntegerLiteral)expression1, (IntegerLiteral)expression2);
            }

            throw new NotImplementedException("Constant expression comparison is not implemented yet for anything but IntegerLiteral.");
        }

        public static bool ArraySpecifiersAreEquivalent(ArraySpecifier arraySpecifier1, ArraySpecifier arraySpecifier2)
        {
            if (arraySpecifier1 == null && arraySpecifier2 == null)
            {
                return true;
            }

            if (arraySpecifier1 == null || arraySpecifier2 == null)
            {
                return false;
            }

            return ConstantExpressionValuesAreEquivalent(arraySpecifier1.ArraySizeExpression, arraySpecifier2.ArraySizeExpression);
        }

        private static bool StructTypeSpecifiersAreEquivalent(StructTypeSpecifier typeSpecifier1, StructTypeSpecifier typeSpecifier2, bool compareQualifier = false)
        {
            if (!IdentifiersAreEquivalent(typeSpecifier1.Identifier, typeSpecifier2.Identifier))
            {
                return false;
            }

            if (typeSpecifier1.Members == null && typeSpecifier2.Members == null)
            {
                return true;
            }

            if (typeSpecifier1.Members?.Count != typeSpecifier2.Members?.Count)
            {
                return false;
            }            

            if (compareQualifier && !TypeQualifiersAreEquivalent(typeSpecifier1.Qualifier, typeSpecifier2.Qualifier))
            {
                return false;
            }

            for (var i = 0; i < typeSpecifier1.Members.Count; i++)
            {
                var member1 = typeSpecifier1.Members[i];
                var member2 = typeSpecifier2.Members[i];
                if (!ArraySpecifiersAreEquivalent(member1.ArraySpecifier, member2.ArraySpecifier))
                {
                    return false;
                }

                if (!TypeSpecifiersAreEquivalent(member1.Type, member2.Type, compareQualifier))
                {
                    return false;
                }

                if (member1.Identifiers.Count != member2.Identifiers.Count)
                {
                    return false;
                }

                for (var id = 0; id < member1.Identifiers.Count; id++)
                {
                    var found = false;
                    for (var id2 = 0; id2 < member2.Identifiers.Count; id2++)
                    {
                        if (IdentifiersAreEquivalent(member1.Identifiers[id], member2.Identifiers[id2]))
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool TypeQualifiersAreEquivalent(TypeQualifier typeQualifier1, TypeQualifier typeQualifier2)
        {
            if (typeQualifier1 == null && typeQualifier2 == null)
            {
                return true;
            }

            if (typeQualifier1 == null || typeQualifier2 == null)
            {
                return false;
            }

            return
                typeQualifier1.Invariant == typeQualifier2.Invariant &&
                typeQualifier1.Interpolation == typeQualifier2.Interpolation &&
                typeQualifier1.Precision == typeQualifier2.Precision &&
                typeQualifier1.Storage == typeQualifier2.Storage &&
                LayoutTypeQualifiersAreEquivalent(typeQualifier1.Layout, typeQualifier2.Layout);
        }

        public static bool LayoutTypeQualifiersAreEquivalent(AstNodeCollection<LayoutIdQualifier> layout1, AstNodeCollection<LayoutIdQualifier> layout2)
        {
            if ((layout1 == null || layout1.Count == 0) && (layout2 == null || layout2.Count == 0))
            {
                return true;
            }

            if (layout1?.Count != layout2?.Count)
            {
                return false;
            }

            Dictionary<string, IntegerLiteral> l1 = new Dictionary<string, IntegerLiteral>();
            Dictionary<string, IntegerLiteral> l2 = new Dictionary<string, IntegerLiteral>();
            var addDelegate = new Action<AstNodeCollection<LayoutIdQualifier>, Dictionary<string, IntegerLiteral>, int>((l, d, ix) =>
            {
                var name = l[ix].Identifier?.Name ?? string.Empty;
                if (!d.ContainsKey(name))
                {
                    d.Add(name, l[ix].Order);
                }
                else
                {
                    d[name] = l[ix].Order;
                }
            });

            for (var i = 0; i < layout1.Count; i++)
            {
                addDelegate(layout1, l1, i);
                addDelegate(layout2, l2, i);
            }

            if (l1.Count != l2.Count)
            {
                return false;
            }

            foreach (var key in l1.Keys)
            {
                if (!l2.ContainsKey(key))
                {
                    return false;
                }

                if (!IntegerLiteralsAreEquivalent(l1[key], l2[key]))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IntegerLiteralsAreEquivalent(IntegerLiteral literal1, IntegerLiteral literal2)
        {
            if (literal1 == null && literal2 == null)
            {
                return true;
            }

            if (literal1 == null || literal2 == null)
            {
                return false;
            }

            int value1 = 0;
            int value2 = 0;

            if (string.IsNullOrEmpty(literal1.LiteralValue) && string.IsNullOrEmpty(literal2.LiteralValue))
            {
                return true;
            }

            if (!(TryParseIntLiteralToInt32(literal1.LiteralValue, out value1) && TryParseIntLiteralToInt32(literal2.LiteralValue, out value2)))
            {
                return false;
            }

            return value1 == value2;
        }

        public static bool TryParseIntLiteralToInt32(string intLiteral, out int result)
        {
            try
            {
                if (intLiteral.StartsWith("0x"))
                {
                    result = Convert.ToInt32(intLiteral.Substring(2), 16);
                    return true;
                }

                if (intLiteral.Length > 1 && intLiteral.StartsWith("0"))
                {
                    result = Convert.ToInt32(intLiteral.TrimStart('0'), 8);
                    return true;
                }

                result = Convert.ToInt32(intLiteral);
                return true;
            }
            catch
            {
                result = 0;
                return false;
            }
        }
    }
}
