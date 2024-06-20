
  /*  Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _topBotRemover("top bottom remover val", Range(0,1)) = 0.8
    }
    SubShader
    {
            ZTest Always Cull Off ZWrite Off Fog{ Mode Off }

        Tags { "RenderType"="Transparent" }
        LOD 100
        ZWrite Off
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct MeshData
            {
                float3 normal : NORMAL;
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Interpolators
            {
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
             //   UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_TexelSize;
            float4 step_w;
            float4 step_h;
            float _topBotRemover;

                float4 _MainTex_ST;
            float4 _MainTex_ST_TexelSize;

            Interpolators vert (MeshData v)
            {
                Interpolators o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = v.normal;
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                //UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            float4 frag (Interpolators i) : SV_Target
            {
                  float2 cordis = i.uv;
                  cordis *= 5;

                  float2 pointsOnLaLi = float2(clamp(cordis.x,0.5,7.5),0.5);

                  //float sdf = distance(cordis,pointsOnLaLi);
                 // clip(distance(pointsOnLaLi, cordis.x));
                
                
                // sample the texture
                float4 col = tex2D(_MainTex, i.uv) ;
          //      float topBottomRemover = (abs(i.normal.y) < _topBotRemover);//*_Rangiet1Pt2;
             //   float t = i.uv.y < 0.555 && i.uv.x < 0.888;
               // float sdf
              //  sdf = 
                float4 lerpi = lerp(col.x,col.z,i.uv.x) * ( cordis.x);
                // apply fog
              //  UNITY_APPLY_FOG(i.fogCoord, col);
                
                return lerpi;
            }
            ENDCG
        }
    }
}*/


Texture2D inputTexture; // Input texture to apply the shader
SamplerState samplerState; // Sampler state for texture sampling

// Define the color palette
static const float4 palette[256] =
{
    // Insert your desired color values here
    // Each color should be in the range of 0 to 1 for each channel (RGBA)
};

// PSX-style shader pixel shader
float4 PSXShaderPS(float4 position : SV_Position, float2 texCoord : TEXCOORD) : SV_Target
{
    // Reduce resolution by downscaling
    float2 downscaledUV = texCoord * float2(320.0f, 240.0f);

    // Retrieve the original color from the input texture
    float4 originalColor = inputTexture.Sample(samplerState, texCoord);

    // Apply dithering effect
    float2 ditherUV = floor(downscaledUV) + frac(downscaledUV) * 0.5f;
    float4 ditheredColor = inputTexture.Sample(samplerState, ditherUV);

    // Apply color quantization to the closest color in the palette
    float3 quantizedColor = round(originalColor.rgb * 255.0f) / 255.0f;
    float4 finalColor = float4(palette[(int)(quantizedColor.r * 255.0f)], palette[(int)(quantizedColor.g * 255.0f)], palette[(int)(quantizedColor.b * 255.0f)], originalColor.a);

    // Simulate scanlines
    float scanlineFactor = step(frac(texCoord.y * 240.0f), 0.02f); // Adjust the second parameter for scanline intensity
    finalColor.rgb -= scanlineFactor * 0.2f; // Adjust the subtraction factor for scanline darkness

    return finalColor;
}

technique PSXShaderTechnique
{
    pass PSXShaderPass
    {
        PixelShader = compile ps_5_0 PSXShaderPS();
    }
}*/




Shader "Unlit/testingDaTestAndStudies"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
    }

    SubShader
    {
        Tags { "RenderType"="Transparent" 
                    "Queue"="Transparent"
            }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_TexelSize;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // Reduce resolution by downscaling
                float2 downscaledUV = i.uv * float2(320.0f, 240.0f);

                // Retrieve the original color from the input texture
                fixed4 originalColor = tex2D(_MainTex, i.uv);

                // Apply dithering effect
                float2 ditherUV = floor(downscaledUV) + frac(downscaledUV) * 0.5f;
                fixed4 ditheredColor = tex2D(_MainTex, ditherUV);

                // Apply color quantization to the closest color in the palette
                float3 quantizedColor = round(originalColor.rgb * 255.0f) / 255.0f;
                fixed4 finalColor = fixed4(quantizedColor.r, quantizedColor.g, quantizedColor.b, originalColor.a);

                // Simulate scanlines
                float scanlineFactor = step(frac(i.uv.y * 240.0f), 0.02f); // Adjust the second parameter for scanline intensity
                finalColor.rgb -= scanlineFactor * 0.2f; // Adjust the subtraction factor for scanline darkness

                return finalColor;
            }

            ENDCG
        }
    }
    
}








