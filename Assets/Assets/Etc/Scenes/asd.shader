Shader "Unlit/asd"
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
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
               // UNITY_FOG_COORDS(1)
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
                float2 ditherUV = floor(downscaledUV) + frac(downscaledUV) * 2.0f;
                fixed4 ditheredColor = tex2D(_MainTex, ditherUV);

                // Apply color quantization to the closest color in the palette
                float3 quantizedColor = round(originalColor.rgb * 255.0f) / 255.0f ;
                fixed4 finalColor = fixed4(quantizedColor.r, quantizedColor.g, quantizedColor.b, originalColor.a);

                // Simulate scanlines
                float scanlineFactor = step(frac(i.uv.y * 240.0f), 0.02f); // Adjust the second parameter for scanline intensity
                finalColor.rgb -= scanlineFactor * 0.2f ; // Adjust the subtraction factor for scanline darkness

                return finalColor;
            }



            ENDCG
        }

    }
}
