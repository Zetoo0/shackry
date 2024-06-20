Shader "Unlit/Lightning"
{
    Properties
    {
        _RockAlbedo ("Rock Albedo", 2D) = "white" {}
        _RockHeight ("Rock Height", 2D) = "gray" {}
        _DiffuseIBL ("Diffuse IBL", 2D) = "black" {}
        _SpecularIBL ("Specular IBL", 2D) = "black" {}
        [NoScaleOffset]_RockNormals ("Rock Normals", 2D) = "bump" {}
        _Gloss("Glossiness", Range(0,1)) = 1
        _Color("Color", Color) = (1,1,1,1)
        _AmbientLight("Ambient Light", Color) = (0,0,0,0)
        _Fresnel("Fresnel strength", Range(0,1)) = 0.5
        _NormalIntensity("Normal Intensity", Range(0,10)) = 0.5
        _DisplacementStrength("Displacement Strength", Range(0,10)) = 0.5
    }
    SubShader
    {
        Tags{
                    "RenderType"="Opaque"
                    "Queue"="Geometry"            
                }

                //Base
            Pass
            {         
                Tags{"LightMode" = "ForwardBase"}
                CGPROGRAM
                #define IF_IS_IN_BASE_PASS
                #pragma vertex vert
                #pragma fragment frag
                // make fog work
             //   #pragma multi_compile_fog
                #include "FGLightning.cginc"
                             ENDCG   

            }

             //Add
            Pass
            {
                Tags{"LightMode" = "ForwardAdd"}

                Blend One One
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma multi_compile_fwadd
                // make fog work
             //   #pragma multi_compile_fog


                #include "FGLightning.cginc"
                             ENDCG   

            }
        }
    }
