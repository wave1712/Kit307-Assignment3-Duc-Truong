Shader "BlinnPhong" {
    Properties{
        _MainTex("Main Texture", 2D) = "white" {}
        _MySpecColor("Specular Color", Color) = (1, 1, 1, 1)
        _Shininess("Shininess", Range(1, 100)) = 20
    }

        SubShader{
            Tags { "RenderType" = "Opaque" }
            LOD 100

            CGPROGRAM
            #pragma surface surf BlinnPhong

            sampler2D _MainTex;
            float4 _MySpecColor;
            float _Shininess;

            struct Input {
                float2 uv_MainTex;
                float3 viewDir;
            };

            void surf(Input IN, inout SurfaceOutput o) {
                half4 texColor = tex2D(_MainTex, IN.uv_MainTex);
                o.Albedo = texColor.rgb;

                half3 normal = normalize(o.Normal);
                half3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                half3 halfwayDir = normalize(lightDir + IN.viewDir);

                float specFactor = pow(max(dot(normal, halfwayDir), 0.0), _Shininess);
                o.Specular = specFactor * _MySpecColor.rgb;
            }
            ENDCG
        }

            FallBack "Diffuse"
}