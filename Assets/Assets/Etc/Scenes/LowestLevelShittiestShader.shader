Shader "Unlit/LowestLevelShittiestShader"
{
    Properties{
       _ColorieyA("Color A ", Color) = (1,1,1,1)
       _ColorieyB("Color B ", Color) = (1,1,1,1)
       _ColorStart ("Color Start", Range(0,1)) = 0
       _ColorEnd("Color End", Range(0,1)) = 1
       _Rangiet1Pt2("RangieKe", Range(0,100)) = 0
       _CosineTauMultiplier("Cosine Tau Multiply", Range(0,100)) = 1
       _SineTauMultiplier("Sine Tau Multiply", Range(0,100)) = 1
    }
        SubShader{
            Tags { "RenderType"="Transparent" 
                    "Queue"="Transparent"
            }
          //  LOD 100

            Pass{

                ZWrite Off
                Blend One One // additive blending





                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                // make fog work
               // #pragma multi_compile_fog

                #include "UnityCG.cginc"

                #define TAU 6.28318530718

                float4 _ColorieyA;
                float4 _ColorieyB;
                float _ColorStart;
                float _ColorEnd;

                float _Rangiet1Pt2;

                float _CosineTauMultiplier;
                float _SineTauMultiplier;

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

            Interpolators vert (MeshData v){
                Interpolators o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = UnityObjectToWorldNormal(v.normals);//fordítva->mul((float3x3)unity_WorldToObject,v.normals)////just pass through
                o.uv = v.uv0;//(v.uv0 * _offset)*_Scale;
                //o.vertex = UnityObjectToClipPos(v.vertex);
                //o.uv = TRANSFORM_TEX(v.uv, _MainTex);
              //66  UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            float InverseLerp(float a, float b, float input){
                return (input-a)/(b-a);
            }



            float4 frag(Interpolators i) : SV_Target
            {
                //lerpike szörpike

               // float t = saturate( InverseLerp( _ColorStart, _ColorEnd,i.uv.x ) );
                //float4 outCol = lerp(_ColorieyA,_ColorieyB,t);
              //  t = frac(t);
                //frac = v - floor(v);

                

               // float t = abs(frac(i.uv.x * 5)*2-1);//)*unity_DeltaTime;
                float xOffset = cos(i.uv.x * TAU * 6) * 0.01;
                float t = cos( (i.uv.y+ xOffset - _Time.y*0.1)*TAU * 5 )* 0.5 + 0.5;
               // t /= i.uv.y;
                t *= 1-i.uv.y;
               //float t1 = sin(i.uv.x*1-1)+cos(i.uv.y*47-1);
                // float t = cos(i.uv.x * TAU * _CosineTauMultiplier+sin(_Time.x) * 0.5 + 0.5)*(sin(i.uv.y*TAU*_SineTauMultiplier+cos(_Time.y))*0.5+0.5);
                //float t2 = cos(i.uv.x*1-1)*sin(i.uv.y*47-1);
               float topBottomRemover = (abs(i.normal.y) < 0.666);//*_Rangiet1Pt2;
               float wavey = t * topBottomRemover;

               float4 gradient = lerp(_ColorieyA, _ColorieyB, i.uv.y);

               return gradient * wavey;

               // return (t1+t2)*_Rangiet1Pt2;//(t*t)/(t-0.1);
                //return outCol;


                // float4 _val;

                // float2 _val_xy = _val.gr;//swizzling
                                          // sample the texture
                 //fixed4 col = tex2D(_MainTex, i.uv);
                 // apply fog
                // UNITY_APPLY_FOG(i.fogCoord, col);
                // return outCol;
            }
            ENDCG
        }
    }
}
