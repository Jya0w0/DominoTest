Shader "Custom/test2Shader"
{
    Properties
    {
        _TopColor ("Top Color", Color) = (1, 0, 0, 1)
        _BottomColor ("Bottom Color", Color) = (0, 0, 1, 1)
        _MinHeight ("Minimum Height", Float) = 0.0
        _MaxHeight ("Maximum Height", Float) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _TopColor;
            float4 _BottomColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.vertex.xy;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Interpolate between top and bottom color based on the y coordinate
                float gradientFactor = i.uv.y;
                fixed4 color = lerp(_BottomColor, _TopColor, gradientFactor);
                return color;
            }
            ENDCG
        }
  
    }
    FallBack "Diffuse"
}
