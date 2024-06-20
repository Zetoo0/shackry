Shader "Unlit/LowestLevelShittiestShader"
{
    Properties{
        _health("Health", Range(0,1)) = 1
        _healthBFlashFreq("Health Bar Flash Frequency", Range(0,100)) = 0.4
        _healthBFlashAmp("Health Bar Flash Amplitude", Range(0,100)) = 0.4
      //  _MainTex("Texture", Texture2D )
         _MainTex ("Texture", 2D) = "white" {}
        _sizeOfBorder("Size of border", Range(0,1)) = 0.2


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
                float _healthBFlashFreq;
                float _healthBFlashAmp;
                float _sizeOfBorder;

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
              //  o.normal = UnityObjectToWorldNormal(v.normals);//ford�tva->mul((float3x3)unity_WorldToObject,v.normals)////just pass through
                o.uv = v.uv0;
                return o;
            }

            float InverseLerp(float a, float b, float input){
                return (input-a)/(b-a);
            }

            float4 frag(Interpolators i) : SV_Target{

            float2 cords = i.uv;
            cords.x *= 8;

            float2 pointOnLineSegm = float2(clamp(cords.x, 0.5,7.5),0.5);

            float sdf = distance(cords, pointOnLineSegm)*2-1;

            clip(-sdf);

            float borderSdf = sdf + _sizeOfBorder;

            float screenSpacePD = fwidth(borderSdf);

            float screenSpacePDMoreBetter = length(float2(ddx(borderSdf),ddy(borderSdf)));

            float borderMask = 1-saturate(borderSdf / screenSpacePDMoreBetter);//step(0,-borderSdf); one minus is the more correct way to invert


          //  return float4(borderMask.xxx,1);



            float healthBMask = _health > i.uv.x;


            float3 healthCol = tex2D(_MainTex, float2(_health, i.uv.y));

            if(_health <= 0.25){
                float flash = cos(_Time.y * _healthBFlashFreq) * _healthBFlashAmp + 1;
                healthCol*=flash;
            }
                
             return float4(healthCol * healthBMask * borderMask, 1);//float4(healthCol, 1);
            
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
