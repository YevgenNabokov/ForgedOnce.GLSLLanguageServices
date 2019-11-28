using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Semantic
{
    public static class ScopeExtensions
    {
        public static IEnumerable<SymbolReference> GetUnresolvedReferences(this Scope scope)
        {
            return scope.References.Values.SelectMany(l => l).Where(r => r.ResolvedSymbol == null).Concat(scope.Scopes.SelectMany(c => c.GetUnresolvedReferences()));
        }

        public static IEnumerable<SymbolReference> GetReferences(this Scope scope)
        {
            return scope.References.Values.SelectMany(l => l).Concat(scope.Scopes.SelectMany(c => c.GetReferences()));
        }
    }
}
