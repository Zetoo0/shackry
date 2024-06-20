Shader "Unlit/SDFExamp"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _Color2("Color 2", Color) = (1,1,1,1)
        _Color3("Color 3", Color) = (1,1,1,1)
        _Strength("Strength", Range(0,1)) = 0.2
        _Size("Size", Range(0,10)) = 0.5
        _Intesity("Intensity", Range(0,100)) = 0.5
        _TimeIntensify("Time Intensity", Range(0,10)) = 0.5
        _Sliding("Sliding", Range(0,1)) = 0.5
        _MainTex ("Texture", 2D) = "white" {}
        _RedOffset("Red Offset", Range(0,255)) = 1.0
        _GreenOffset("Green Offset", Range(0,255)) = 1.0
        _BlueOffset("Blue Offset", Range(0,255)) = 1.0

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
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

                            #define TAU 6.28318530718


            float4 _Color;
            float4 _Color2;
            float4 _Color3;
            float _Strength;
            float _Size;
            float _Intesity;
            float _TimeIntensify;
            float _Sliding;
            float _RedOffset;
            float _GreenOffset;
            float _BlueOffset;


            struct MeshData
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normals : NORMAL;
                
            };

            struct Interpolators
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 normal : NORMAL;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
           

            Interpolators vert (MeshData v)
            {
                Interpolators o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv * 2 - 1;
               // float3 dpdx = ddx(UnityObjectToWorldPos);
               // float3 dpdy = ddy(UnityObjectToWorldPos);
               
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (Interpolators i) : SV_Target
            {
                
                return float4(_Color.Red+_RedOffset,_Color.Green + _GreenOffset, _Color.Blue + _BlueOffset,0);

               /* float dist = length(sin(i.uv))+_Time.y;//* _Intesity + _Sliding); //- _Size * 2;    //* 4 * _Time.y * _TimeIntensify;//SDF -> signed distance field CIRCLE
                float2 componentWiseEdgeDistance = (cos(abs(i.uv.x))-(i.uv.y*2))*_Intesity + _Sliding; //- (i.uv.y/8) * _Time.x; -> rectangle stuffsx
                //float2 normalu = normalize(i.uv)+_Strength*_Time.x;
                //float2 displ = clamp((normalu - 0.5)*_Strength,-1,1);
              //  i.uv += displ;
                
               // if(i.uv.x < 0.5){
                 //  return 1-(_Color) + tex2D(_MainTex, (i.uv));
                //}
              //  return float4(i.uv,0,0);
               float sdf = length(sin(i.uv))+_Time.y;//* length(sin(i.uv.x))-0.5 * length(cos(i.uv.xy)) + length(log2(sin(cos(atan(acos(asin(tan(i.uv.x)))))))))-1;
              // float ksdf = sdf + 3;
              ///6/ float screenSpacePD = length(float2(ddx(ksdf),ddy(ksdf)); 
              //clip(sdf)
              // float3 val = lerp(0,1,_Sliding);
               if(lerp(sdf,1,_Sliding)  > 0.5 ){
                return float4(sdf,sdf,sdf*_Time.y,0) ;
                  }
               clip(sdf);
                return 1;*/
             //   return float4(1,1,1,1);
               //if(sdf < 0)
                //return float4(0.20,0.11,0.4,0);
               //}
              // return float4(1,1,1,1);
                //(length(i.uv))*_Intesity+_Sliding*_Color
              // i.uv = smoothstep(1-_Intesity, _Intesity, i.uv);
               /* if(dist < 0){
                return float4(0.56,0.12,0.23,0);
                }*/

                // sample the texture
               // fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                //return float4(,1);
               // float Slide = clamp(_Sliding,1,-1)
               // return _Color+tex2D(_MainTex, (i.uv)    );
              //  return  float4(componentWiseEdgeDistance.xxx*_Color,0);//*_Color + _Strength * (_Color2)  ,0.3,0);//sin(dist.xxx) * _Color - _Strength * (_Color2) + (_Color3) ,0);
            }
            ENDCG
        }
    }
}
