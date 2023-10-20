Shader "ScatterLightShader" {
    Properties{
        _MainTex("Main Texture", 2D) = "white" {}
        _BacklightColor("Backlight Color", Color) = (1,1,1,1)
        _BacklightStrength("Backlight Strength", Range(0, 5)) = 2.0
    }

        SubShader{
            Tags { "RenderType" = "Opaque" }
            LOD 100

            CGPROGRAM
            #pragma surface surf Lambert

            sampler2D _MainTex;
            float3 _BacklightColor;
            float _BacklightStrength;

            struct Input {
                float2 uv_MainTex;
                float3 worldNormal;
                float3 worldPos;
            };

            void surf(Input IN, inout SurfaceOutput o) {
                half4 texColor = tex2D(_MainTex, IN.uv_MainTex);
                o.Albedo = texColor.rgb;

                
                float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                float nl = dot(IN.worldNormal, lightDir);
                o.Emission = _BacklightColor * _BacklightStrength * max(0, -nl);
            }
            ENDCG
        }

            FallBack "Diffuse"
}
