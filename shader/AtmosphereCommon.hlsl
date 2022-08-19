#ifndef ATMOSPHERE_COMMON_INCLUDE
#define ATMOSPHERE_COMMON_INCLUDE


    struct appdata
    {
        float4 uv : TEXCOORD0;
        uint vertexID : SV_VertexID;
    };
                
    struct v2f
    {
        float4 uv : TEXCOORD0;
        float4 vertex : SV_POSITION;
    };

    v2f AtmosphereVert(appdata v)
    {
        v2f o;
        uint vertexID = v.vertexID;
        float2 uv = float2((vertexID << 1) & 2,vertexID & 2);
        float4 posCS = float4(uv * 2.0 - 1.0, 0.0, 1.0);
        //#if UNITY_UV_STARTS_AT_TOP
        uv.y = 1.0 - uv.y;
        //#endif
        o.vertex = posCS;

        // Standard RP
        o.uv = float4(uv.xy, 0, 1);
    
        return o;
    }




#endif