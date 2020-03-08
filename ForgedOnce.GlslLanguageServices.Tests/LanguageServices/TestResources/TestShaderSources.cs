using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.Tests.LanguageServices.TestResources
{
    public static class TestShaderSources
    {
        public static string BigShaderText
        {
            get
            {
                return @"
#version 300 es

precision highp int;

precision highp float;

precision highp usampler3D;

precision highp usampler1D;

in vec4 position;

in vec3 normal;

in vec2 uv;

//out vec3 v_normal;

out vec3 inWorldPos;

out vec3 lightResult;

uniform mat4 transform;
uniform mat4 world;

//// Lighting
const vec3 lightDir = vec3(0.0, 1.0, -1.0);
const vec3 lightDir1 = vec3(0.0, 1.0, 0.0);

const float lightColorMax = 7.0;
const float ambientLightPresenceMax = 31.0;
const float lightIntensityMax = 63.0;

uniform usampler3D lightingOctree[12];
uniform int maxRank;
uniform int octreeDimension;
uniform mat4 flatRankShifts;
uniform mat4 rankDimensions;
uniform mat4 rankVolumes;
uniform float octreeScale;

uniform float ambientLightLevel;
uniform vec3 ambientLightColor;

struct OctreeNode
{
	bool ContainsData;
	bool HasChild;
	uint Rank;
	uint AmbientLightPresence;
	vec3 LightColor;	
	float LigthIntensity;
	bool HasLight;
};

float NodeValueToFloat(uint value, float maxValue)
{
	return float(value) / maxValue;
}

void GetHasChild(uint data, out bool hasChild)
{
	hasChild = ((data >> 10) & 0x1u) == 1u;
}

uint ReadOctreeRankData(mat4 data, int rank)
{
	return uint(data[uint(rank) / 4u][uint(rank) % 4u]);
}

void UnpackNode(uint data, out OctreeNode node)
{
	bool hasChild;
	GetHasChild(data, hasChild);

	node.HasChild = hasChild;
	node.AmbientLightPresence = (data >> 12) & 0x1fu;
	node.LightColor = vec3(smoothstep(0.0, lightColorMax, float((data >> 23) & 0x7u)), smoothstep(0.0, lightColorMax, float((data >> 20) & 0x7u)), smoothstep(0.0, lightColorMax, float((data >> 17) & 0x7u)));
	node.LigthIntensity = NodeValueToFloat((data >> 26) & 0x3fu, lightIntensityMax);
	node.HasLight = ((data >> 11) & 0x1u) == 1u;
}

ivec3 MapNode(int nodeRank, uint x, uint y, uint z)
{
	if (nodeRank == maxRank) {
		return ivec3(x, y, z);
	}

	uint rankDimension = ReadOctreeRankData(rankDimensions, nodeRank);
	uint maxRankDimension = ReadOctreeRankData(rankDimensions, maxRank);

	uint flatIndex = ReadOctreeRankData(flatRankShifts, nodeRank) + x + y * rankDimension + z * rankDimension * rankDimension;
	uint iz = (flatIndex / (maxRankDimension * maxRankDimension)) + uint(octreeDimension);
	flatIndex = flatIndex % (maxRankDimension * maxRankDimension);
	uint iy = flatIndex / maxRankDimension;
	uint ix = (flatIndex % maxRankDimension);

	return ivec3(ix, iy, iz);
}

void GetLightingData(vec3 position, int startRank, out OctreeNode node)
{
	if (position.x >= 0.0 && position.x < float(octreeDimension) && position.y >= 0.0 && position.y < float(octreeDimension) && position.z >= 0.0 && position.z < float(octreeDimension))
	{
		node.ContainsData = true;
		for (int r = startRank; r <= maxRank; r++)
		{
			float rankDim = pow(2.0, float(maxRank - r));
			//ivec3 texelAddress = ivec3(floor(position.x / rankDim), floor(position.y / rankDim), floor(position.z / rankDim));
			ivec3 texelAddress = MapNode(r, uint(floor(position.x / rankDim)), uint(floor(position.y / rankDim)), uint(floor(position.z / rankDim)));
			uint data = texelFetch(lightingOctree[0], texelAddress, 0).r;
			bool hasChild;
			GetHasChild(data, hasChild);
			if (!hasChild)
			{
				UnpackNode(data, node);

				node.ContainsData = node.ContainsData && node.HasLight;

				//if (r == maxRank - 2) {
				//	node.LightColor = vec3(1.0, 0.0, 0.0);
				//}

				break;
			}
		}
	}
	else
	{
		node.ContainsData = false;
		node.LigthIntensity = 0.0;
	}
}

vec3 MixLights(vec3 light1, vec3 light2)
{
	return vec3(max(light1.r, light2.r), max(light1.g, light2.g), max(light1.b, light2.b));
}

vec3 CalculateLight(vec3 relativePos, OctreeNode lightNode, OctreeNode lightNodex, OctreeNode lightNodey, OctreeNode lightNodez, OctreeNode lightNodexy, OctreeNode lightNodexz, OctreeNode lightNodeyz, OctreeNode lightNodexyz)
{
	vec3 normal = normalize(normal);

	float nonZeroInputs = 0.0;
	vec3 lightSum;
	vec3 ambientLight;
	
	//// New trilinear approach.

	float bx = !lightNode.ContainsData ? lightNodex.LigthIntensity : !lightNodex.ContainsData ? lightNode.LigthIntensity : mix(lightNode.LigthIntensity, lightNodex.LigthIntensity, relativePos.x);	
	if (!lightNode.ContainsData && !lightNodex.ContainsData) { bx = -1.0; }
	float bX = !lightNodey.ContainsData ? lightNodexy.LigthIntensity : !lightNodexy.ContainsData ? lightNodey.LigthIntensity : mix(lightNodey.LigthIntensity, lightNodexy.LigthIntensity, relativePos.x);
	if (!lightNodey.ContainsData && !lightNodexy.ContainsData) { bX = -1.0; }
	float B = bx == -1.0 ? bX : bX == -1.0 ? bx : mix(bx, bX, relativePos.y);

	float tx = !lightNodez.ContainsData ? lightNodexz.LigthIntensity : !lightNodexz.ContainsData ? lightNodez.LigthIntensity : mix(lightNodez.LigthIntensity, lightNodexz.LigthIntensity, relativePos.x);
	if (!lightNodez.ContainsData && !lightNodexz.ContainsData) { tx = -1.0; }
	float tX = !lightNodeyz.ContainsData ? lightNodexyz.LigthIntensity : !lightNodexyz.ContainsData ? lightNodeyz.LigthIntensity : mix(lightNodeyz.LigthIntensity, lightNodexyz.LigthIntensity, relativePos.x);
	if (!lightNodeyz.ContainsData && !lightNodexyz.ContainsData) { tX = -1.0; }
	float T = tx == -1.0 ? tX : tX == -1.0 ? tx : mix(tx, tX, relativePos.y);

	float finalIntensity = B == -1.0 && T == -1.0 ? 0.0 : B == -1.0 ? T : T == -1.0 ? B : mix(B, T, relativePos.z);

	//// Color.

	float cbxL = 1.0;
	vec3 cbx = !lightNode.ContainsData ? lightNodex.LightColor : !lightNodex.ContainsData ? lightNode.LightColor : mix(lightNode.LightColor, lightNodex.LightColor, relativePos.x);
	if (!lightNode.ContainsData && !lightNodex.ContainsData) { cbxL = -1.0; }
	float cbXL = 1.0;
	vec3 cbX = !lightNodey.ContainsData ? lightNodexy.LightColor : !lightNodexy.ContainsData ? lightNodey.LightColor : mix(lightNodey.LightColor, lightNodexy.LightColor, relativePos.x);
	if (!lightNodey.ContainsData && !lightNodexy.ContainsData) { cbXL = -1.0; }
	float cBL = 1.0;
	vec3 cB = cbxL == -1.0 ? cbX : cbXL == -1.0 ? cbx : mix(cbx, cbX, relativePos.y);
	if (cbxL == -1.0 && cbXL == -1.0) { cBL = -1.0; }

	float ctxL = 1.0;
	vec3 ctx = !lightNodez.ContainsData ? lightNodexz.LightColor : !lightNodexz.ContainsData ? lightNodez.LightColor : mix(lightNodez.LightColor, lightNodexz.LightColor, relativePos.x);
	if (!lightNodez.ContainsData && !lightNodexz.ContainsData) { ctxL = -1.0; }
	float ctXL = 1.0;
	vec3 ctX = !lightNodeyz.ContainsData ? lightNodexyz.LightColor : !lightNodexyz.ContainsData ? lightNodeyz.LightColor : mix(lightNodeyz.LightColor, lightNodexyz.LightColor, relativePos.x);
	if (!lightNodeyz.ContainsData && !lightNodexyz.ContainsData) { ctXL = -1.0; }
	float cTL = 1.0;
	vec3 cT = ctxL == -1.0 ? ctX : ctXL == -1.0 ? ctx : mix(ctx, ctX, relativePos.y);
	if (ctxL == -1.0 && ctXL == -1.0) { cTL = -1.0; }

	vec3 finalColor = cBL == -1.0 && cTL == -1.0 ? vec3(0.0) : cBL == -1.0 ? cT : cTL == -1.0 ? cB : mix(cB, cT, relativePos.z);

	///// End.

	//if (relativePos.x < 0.5 && relativePos.y < 0.5 && relativePos.z < 0.5)
	//{
	//	return vec3(1.0, 1.0, 1.0);
	//}

	vec3 finalLight = finalIntensity * finalColor;

	float ambientVariation = dot(normal, lightDir);
	float ambientVariation1 = dot(normal, lightDir1);

	ambientLight = NodeValueToFloat(lightNode.AmbientLightPresence, ambientLightPresenceMax) * (1.0 - 0.3 * ambientVariation - 0.1 * ambientVariation1) * ambientLightLevel * ambientLightColor;
	lightSum += MixLights(finalLight, ambientLight);

	return lightSum;
}

void main()
{	
	vec4 tPos = transform * position;

	inWorldPos = (world * position).xyz;

	//// Lighting

	OctreeNode lightNode;
	OctreeNode lightNodex;	
	OctreeNode lightNodey;	
	OctreeNode lightNodez;	
	OctreeNode lightNodexy;
	OctreeNode lightNodexz;
	OctreeNode lightNodeyz;
	OctreeNode lightNodexyz;	

	vec3 octreePos = inWorldPos / octreeScale;

	vec3 referencePos = vec3(fract(octreePos.x) - 0.5, fract(octreePos.y) - 0.5, fract(octreePos.z) - 0.5);

	GetLightingData(octreePos, 0, lightNode);
	GetLightingData(vec3(octreePos.x + normalize(referencePos.x), octreePos.y, octreePos.z), 0, lightNodex);
	GetLightingData(vec3(octreePos.x, octreePos.y + normalize(referencePos.y), octreePos.z), 0, lightNodey);
	GetLightingData(vec3(octreePos.x, octreePos.y, octreePos.z + normalize(referencePos.z)), 0, lightNodez);
	GetLightingData(vec3(octreePos.x + normalize(referencePos.x) , octreePos.y + normalize(referencePos.y), octreePos.z), 0, lightNodexy);
	GetLightingData(vec3(octreePos.x + normalize(referencePos.x) , octreePos.y, octreePos.z + normalize(referencePos.z)), 0, lightNodexz);
	GetLightingData(vec3(octreePos.x, octreePos.y + normalize(referencePos.y), octreePos.z + normalize(referencePos.z)), 0, lightNodeyz);
	GetLightingData(vec3(octreePos.x + normalize(referencePos.x), octreePos.y + normalize(referencePos.y), octreePos.z + normalize(referencePos.z)), 0, lightNodexyz);
		
	lightResult = CalculateLight(vec3(abs(referencePos.x), abs(referencePos.y), abs(referencePos.z)), lightNode, lightNodex, lightNodey, lightNodez, lightNodexy, lightNodexz, lightNodeyz, lightNodexyz);

	//// Perspective.
	float zToDivideBy = 1.0 + tPos.z;

	gl_Position = vec4(tPos.xyz, zToDivideBy);

	//v_normal = mat3(world) * normal;
}";
            }
        }
    }
}
