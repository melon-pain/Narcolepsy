Shader "Hidden/Custom/Error"
{
    HLSLINCLUDE

#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

    TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);

    float _Blend;

    float rand_1_05(in float2 uv)
    {
        float2 noise = (frac(sin(dot(uv, float2(12.9898, 78.233) * 2.0)) * 1.5453));
        return abs(noise.x + noise.y) * 0.5;
    }

    float4 Frag(VaryingsDefault i) : SV_Target
    {
        float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord * lerp(1, float2 (rand_1_05(i.texcoord)* 5, rand_1_05(i.texcoord) * 2), _Blend));
        return color;
    }

        ENDHLSL

        SubShader
    {
        Cull Off ZWrite Off ZTest Always

            Pass
        {
            HLSLPROGRAM

                #pragma vertex VertDefault
                #pragma fragment Frag

            ENDHLSL
        }
    }
}