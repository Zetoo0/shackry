Shader "Unlit/SkyBoksz"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
// Upgrade NOTE: excluded shader from DX11; has structs without semantics (struct appdata members viewDir)
#pragma exclude_renderers d3d11
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float2 viewDir;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float2 viewDir;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            #define TAU 6.28318530718

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                o.viewDir = v.viewDir;
                return o;
            }

            float2 DirToRectilinear( float3 dir ){

                float x = atan2( dir.z, dir.x ) / TAU + 0.5;//-tau/2 tau/2,,,, 0-1 így
                float y = dir.y * 0.5 + 0.5;//0-100

                return float2(x,y);

            }


            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2Dlod(_MainTex, float4(DirToRectilinear(i.viewDir),0,0);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
