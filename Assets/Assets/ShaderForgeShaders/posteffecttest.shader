// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:1,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:False,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:1,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:6,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:True,qofs:1,qpre:4,rntp:5,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:33049,y:33159,varname:node_2865,prsc:2|emission-4676-OUT,alpha-4676-OUT,olwid-4676-OUT;n:type:ShaderForge.SFN_TexCoord,id:4219,x:31794,y:33215,cmnt:Default coordinates,varname:node_4219,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Relay,id:8397,x:32152,y:33209,cmnt:Refract here,varname:node_8397,prsc:2|IN-4219-UVOUT;n:type:ShaderForge.SFN_Relay,id:4676,x:32794,y:33469,cmnt:Modify color here,varname:node_4676,prsc:2|IN-9905-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:4430,x:31848,y:33472,ptovrint:False,ptlb:MainTex,ptin:_MainTex,cmnt:MainTex contains the color of the scene,varname:node_9933,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7542,x:32173,y:33364,varname:node_1672,prsc:2,ntxv:0,isnm:False|UVIN-8397-OUT,MIP-9871-OUT,TEX-4430-TEX;n:type:ShaderForge.SFN_Noise,id:9871,x:32022,y:33662,varname:node_9871,prsc:2|XY-8397-OUT;n:type:ShaderForge.SFN_Blend,id:7873,x:32246,y:33662,varname:node_7873,prsc:2,blmd:10,clmp:True|SRC-9871-OUT,DST-7542-R;n:type:ShaderForge.SFN_Lerp,id:9905,x:32526,y:33649,varname:node_9905,prsc:2|A-4546-OUT,B-7873-OUT,T-6500-OUT;n:type:ShaderForge.SFN_OneMinus,id:4363,x:32232,y:33882,varname:node_4363,prsc:2|IN-7873-OUT;n:type:ShaderForge.SFN_ChannelBlend,id:4546,x:32442,y:33183,varname:node_4546,prsc:2,chbt:0|M-4363-OUT,R-7542-R,G-7542-G,B-7542-B,A-7542-A;n:type:ShaderForge.SFN_LightVector,id:6500,x:32490,y:33809,varname:node_6500,prsc:2;proporder:4430;pass:END;sub:END;*/

Shader "Shader Forge/posteffecttest" {
    Properties {
        _MainTex ("MainTex", 2D) = "black" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Overlay+1"
            "RenderType"="Overlay"
        }
        Pass {
            Name "Outline"
            Tags {
            }
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float2 node_8397 = o.uv0; // Refract here
                float2 node_9871_skew = node_8397 + 0.2127+node_8397.x*0.3713*node_8397.y;
                float2 node_9871_rnd = 4.789*sin(489.123*(node_9871_skew));
                float node_9871 = frac(node_9871_rnd.x*node_9871_rnd.y*(1+node_9871_skew.x));
                float4 node_1672 = tex2Dlod(_MainTex,float4(TRANSFORM_TEX(node_8397, _MainTex),0.0,node_9871));
                float node_7873 = saturate(( node_1672.r > 0.5 ? (1.0-(1.0-2.0*(node_1672.r-0.5))*(1.0-node_9871)) : (2.0*node_1672.r*node_9871) ));
                float node_4363 = (1.0 - node_7873);
                float node_4546 = (node_4363.r*node_1672.r);
                float3 node_4676 = lerp(float3(node_4546,node_4546,node_4546),float3(node_7873,node_7873,node_7873),lightDirection); // Modify color here
                o.pos = UnityObjectToClipPos( float4(v.vertex.xyz + v.normal*node_4676,1) );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                return fixed4(float3(0,0,0),0);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            ZTest Always
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
////// Emissive:
                float2 node_8397 = i.uv0; // Refract here
                float2 node_9871_skew = node_8397 + 0.2127+node_8397.x*0.3713*node_8397.y;
                float2 node_9871_rnd = 4.789*sin(489.123*(node_9871_skew));
                float node_9871 = frac(node_9871_rnd.x*node_9871_rnd.y*(1+node_9871_skew.x));
                float4 node_1672 = tex2Dlod(_MainTex,float4(TRANSFORM_TEX(node_8397, _MainTex),0.0,node_9871));
                float node_7873 = saturate(( node_1672.r > 0.5 ? (1.0-(1.0-2.0*(node_1672.r-0.5))*(1.0-node_9871)) : (2.0*node_1672.r*node_9871) ));
                float node_4363 = (1.0 - node_7873);
                float node_4546 = (node_4363.r*node_1672.r);
                float3 node_4676 = lerp(float3(node_4546,node_4546,node_4546),float3(node_7873,node_7873,node_7873),lightDirection); // Modify color here
                float3 emissive = node_4676;
                float3 finalColor = emissive;
                return fixed4(finalColor,node_4676);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZTest Always
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                LIGHTING_COORDS(2,3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
////// Lighting:
                float3 finalColor = 0;
                return fixed4(finalColor,0);
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
