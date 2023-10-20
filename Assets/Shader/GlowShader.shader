Shader "GlowShader" {
    Properties{
        _MainTex("Main Texture", 2D) = "white" {}
        _EmissionMap("Emission Control Map", 2D) = "white" {}
        _GlowColor("Glow Color", Color) = (1,1,1,1)
        _GlowThreshold("Glow Threshold", Range(0,1)) = 0.5
        _GlowIntensity("Glow Intensity", Range(0,5)) = 2.0
        _GlowRadius("Glow Radius", Range(0,1)) = 0.5
    }

        SubShader{
            Tags { "RenderType" = "Opaque" }
            LOD 100

            CGPROGRAM
            #pragma surface surf Lambert

            sampler2D _MainTex;
            sampler2D _EmissionMap;
            float4 _GlowColor;
            float _GlowThreshold;
            float _GlowIntensity;
            float _GlowRadius;

            struct Input {
                float2 uv_MainTex;
            };

            void surf(Input IN, inout SurfaceOutput o) {
                half4 c = tex2D(_MainTex, IN.uv_MainTex);
                half4 emissionControl = tex2D(_EmissionMap, IN.uv_MainTex);

                o.Albedo = c.rgb;

                half brightness = dot(emissionControl.rgb, half3(0.3, 0.59, 0.11)); // Luma coefficients
                half distanceFromCenter = length(IN.uv_MainTex - 0.5); // UV distance from center

                if (brightness > _GlowThreshold && distanceFromCenter < _GlowRadius) {
                    half glowAmount = _GlowIntensity * (brightness - _GlowThreshold) / (1 - _GlowThreshold);
                    o.Emission = _GlowColor.rgb * glowAmount;
                }
     else {
      o.Emission = half3(0,0,0);
  }
}
ENDCG
        }
            FallBack "Diffuse"
}
