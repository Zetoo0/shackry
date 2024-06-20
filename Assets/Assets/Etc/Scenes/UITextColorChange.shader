Shader "Unlit/UITextColorChange"
{
    Properties
    {
        _health("Health", Range(0,100)) = 100
        _healthBFlashFreq("Health Bar Flash Frequency", Range(0,100)) = 0.4
        _healthBFlashAmp("Health Bar Flash Amplitude", Range(0,100)) = 0.4
      //  _MainTex("Texture", Texture2D )
         _MainTex ("Texture", 2D) = "white" {}
        _sizeOfBorder("Size of border", Range(0,1)) = 0.2
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        //LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
         //   #pragma multi_compile_fog

            #include "UnityCG.cginc"
            float _health;
            float _healthBFlashFreq;
            float _healthBFlashAmp;
            float _sizeOfBorder;
            
            struct MeshData
            {
                float4 vertex : POSITION;
                float3 normals : NORMAL;
                fixed4 color0 : COLOR;
                float2 uv0 : TEXCOORD1;
            };

            struct Interpolators
            {
                float4 vertex : SV_POSITION;//clip space pos 
                float3 normal : TEXCOORD0;
               // UNITY_FOG_COORDS(1)  
                float2 uv : TEXCOORD1;
                fixed4 color : COLOR;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            Interpolators vert (MeshData v)
            {
                 Interpolators o;
                o.vertex = UnityObjectToClipPos(v.vertex);
              //  o.normal = UnityObjectToWorldNormal(v.normals);//ford�tva->mul((float3x3)unity_WorldToObject,v.normals)////just pass through
                o.uv = v.uv0;
                o.color = v.color0;
                return o;
            }

            fixed4 frag (Interpolators i) : SV_Target
            {
                // sample the texture
                float3 health_color = tex2D(_MainTex, float2(_health,i.uv.y));
                // apply fog
              //  UNITY_APPLY_FOG(i.fogCoord, col);
                
                if(_health < 25)
                {
                    float flash = cos(_Time.y * _healthBFlashFreq) * _healthBFlashAmp + 1;
                    health_color *= flash;
                }
                return float4(health_color,1);
            }
            ENDCG
        }
    }
}
