Shader "RealisticShader" {
    Properties{
        _MainTex("Main Texture", 2D) = "white" {}
        _Roughness("Roughness", Range(0,1)) = 0.5
        _Metallic("Metallic", Range(0,1)) = 0.5
    }

        SubShader{
            Tags { "RenderType" = "Opaque" }
            LOD 100

            CGPROGRAM
            #pragma surface surf Standard

            sampler2D _MainTex;
            float _Roughness;
            float _Metallic;

            struct Input {
                float2 uv_MainTex;
            };

            void surf(Input IN, inout SurfaceOutputStandard o) {
                half4 c = tex2D(_MainTex, IN.uv_MainTex);
                o.Albedo = c.rgb;
                o.Smoothness = 1.0 - _Roughness;
                o.Metallic = _Metallic;
            }
            ENDCG
        }
            FallBack "Diffuse"
}
