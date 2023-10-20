Shader "Shader/Circle"
{
    Properties
    {
        _Color ("Main Color", Color) = (1,1,1,1)
        _MainTex ("Base (RGB)", 2D) = "white" { }
    }

    SubShader
    {
        Tags {"Queue"="Overlay" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma exclude_renderers gles xbox360 ps3
            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct v2f
            {
                float4 pos : POSITION;
                float3 normal : NORMAL;
            };
            uniform float4 _Color;
            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.normal = UnityObjectToWorldNormal(v.normal);
                return o;
            }
            fixed4 frag(v2f i) : COLOR
            {
                return _Color;
            }
            ENDCG
        }
    }

    FallBack "Diffuse"
}
