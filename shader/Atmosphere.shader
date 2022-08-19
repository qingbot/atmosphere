Shader "Unlit/Atmosphere"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {

        ZTest off
        Cull off
        ZWrite off

        Pass
        {

            name "Atmosphere"
            HLSLPROGRAM
            #pragma vertex AtmosphereVert
            #pragma fragment frag

            #include "AtmosphereCommon.hlsl"

            sampler2D _CameraDepthTexture;

            sampler2D _cameraTexture1;

            float4 frag (v2f i) : SV_Target
            {
                return tex2D(_cameraTexture1,i.uv);
            }
            ENDHLSL
        }
    }
}
