Shader "ReflectShader" {
    Properties{
        _MainTex("Main Texture", 2D) = "white" {}
        _HeightMap("Height Map", 2D) = "white" {}
        _TessellationFactor("Tessellation Factor", Range(1, 10)) = 5
        _Height("Height", Range(0, 1)) = 0.1
    }

        SubShader{
            Pass {
                CGPROGRAM
                #pragma target 5.0
                #pragma vertex vert
                #pragma tessellate tess
                #pragma fragment frag

                sampler2D _MainTex;
                sampler2D _HeightMap;
                float _TessellationFactor;
                float _Height;

                struct appdata {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct tessdata {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                    float tessellation : TESSCOORD;
                };

                tessdata vert(appdata v) {
                    tessdata o;
                    o.vertex = v.vertex;
                    o.uv = v.uv;
                    o.tessellation = _TessellationFactor;
                    return o;
                }

                [domain("quad")]
                [partitioning("integer")]
                [outputtopology("triangle_ccw")]
                [outputcontrolpoints(4)]
                [patchconstantfunc("patchFunc")]
                float4 tess(uint id : SV_OutputControlPointID, tessdata input) : SV_POSITION {
                    return input.vertex;
                }

                float4 patchFunc() : SV_TessFactor {
                    return float4(_TessellationFactor, _TessellationFactor, _TessellationFactor, _TessellationFactor);
                }

                half4 frag(tessdata i) : SV_Target {
                    half disp = tex2D(_HeightMap, i.uv).r * _Height;
                    half4 col = tex2D(_MainTex, i.uv + disp);
                    return col;
                }
                ENDCG
            }
        }
}
