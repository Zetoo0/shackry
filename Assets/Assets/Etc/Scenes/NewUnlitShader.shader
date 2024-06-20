Shader "Unlit/LowestLevelShittiestShader"
{
    Properties{
        _health("Health", Range(0,1)) = 1
      //  _MainTex("Texture", Texture2D )
        _MainTex ("Texture", 2D) = "white" {}

    }

        SubShader{
            Tags { "RenderType"="Transparent" "Queue"="Transparent" 
            }
          //  LOD 100

            Pass{

                ZWrite Off
                Blend SrcAlpha OneMinusSrcAlpha // 

                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                // make fog work
               // #pragma multi_compile_fog

                #include "UnityCG.cginc"

                #define TAU 6.28318530718
          
                float _health;

            struct MeshData{
                float4 vertex : POSITION;//vertex pos
                float3 normals : NORMAL;
               // float2 uv : TEXCOORD0;
                float2 uv0 : TEXCOORD0;

            };

            struct Interpolators{
                float4 vertex : SV_POSITION;//clip space pos 
                float3 normal : TEXCOORD0;
               // UNITY_FOG_COORDS(1)
                float2 uv : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;



            Interpolators vert(MeshData v){
                Interpolators o;

                o.vertex = UnityObjectToClipPos(v.vertex);
              //  o.normal = UnityObjectToWorldNormal(v.normals);//fordítva->mul((float3x3)unity_WorldToObject,v.normals)////just pass through
                o.uv = v.uv0;
                return o;
            }

            float InverseLerp(float a, float b, float input){
                return (input-a)/(b-a);
            }


            float4 frag(Interpolators i) : SV_Target{
                return float 4(0.0,0.0,0.0,0.0);
          //      healthBMask = _health > i.uv.x;//

                //float3 healthCol = tex2D(_MainTex, float2(_health, i.uv.y));
               //  return float4(healthCol * healthBMask, 1);
            
            /*PART1
          //  return float4(1,0,0,i.uv.x);

            float healthMask = _health > i.uv.x;
            //clip(healthMask - 0.1);

            float tHealthCol = saturate(InverseLerp(0.2, 0.8, _health));
            float3 healthBColor = lerp(float3(1,0,0), float3(0,1,0),tHealthCol);
            
           // float3 backgroundCol = float3(0,0,0);


         //   float3 outCol = lerp(backgroundCol, healthBColor, healthMask);

           // float4 col = tex2D(_MainTex, i.uv);
           // return col;
           return float4(healthBColor,healthMask);
           //return float4( i.uv ,0,0);*/
            }
            ENDCG
        }   
    }
}
