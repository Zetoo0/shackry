// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:328,x:33093,y:32351,varname:node_328,prsc:2|diff-3989-OUT,diffpow-5269-OUT,spec-6293-R,emission-5269-OUT,alpha-8494-R,olwid-8494-G,olcol-6293-RGB,voffset-6293-A,tess-6441-OUT,tessPhong-6293-A;n:type:ShaderForge.SFN_TexCoord,id:3074,x:31667,y:32786,varname:node_3074,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:8494,x:32160,y:32799,ptovrint:False,ptlb:node_8494,ptin:_node_8494,varname:node_8494,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6538ed284d1f92144801a856c41d0666,ntxv:0,isnm:False|UVIN-3074-UVOUT,MIP-3074-V;n:type:ShaderForge.SFN_ValueProperty,id:1521,x:31948,y:32584,ptovrint:False,ptlb:TEX_MIP_VAL,ptin:_TEX_MIP_VAL,varname:node_1521,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ChannelBlend,id:1523,x:31916,y:32962,varname:node_1523,prsc:2,chbt:0|M-3074-U,R-6267-OUT;n:type:ShaderForge.SFN_Abs,id:4151,x:32160,y:33059,varname:node_4151,prsc:2|IN-8494-R;n:type:ShaderForge.SFN_Blend,id:5269,x:32369,y:33221,varname:node_5269,prsc:2,blmd:10,clmp:True|SRC-1436-OUT,DST-277-OUT;n:type:ShaderForge.SFN_Distance,id:6733,x:32160,y:33221,varname:node_6733,prsc:2|A-4151-OUT,B-1523-OUT;n:type:ShaderForge.SFN_SceneDepth,id:6267,x:31638,y:33074,varname:node_6267,prsc:2|UV-3074-UVOUT;n:type:ShaderForge.SFN_Color,id:6293,x:32094,y:32435,ptovrint:False,ptlb:outline_color,ptin:_outline_color,varname:node_6293,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.8490566,c2:0.500623,c3:0.500623,c4:1;n:type:ShaderForge.SFN_Frac,id:3989,x:32603,y:33202,varname:node_3989,prsc:2|IN-5269-OUT;n:type:ShaderForge.SFN_Depth,id:1436,x:32293,y:33385,varname:node_1436,prsc:2;n:type:ShaderForge.SFN_ChannelBlend,id:277,x:32511,y:32937,varname:node_277,prsc:2,chbt:0|M-8494-RGB,R-8494-R,G-8494-G,B-8494-B,A-4151-OUT;n:type:ShaderForge.SFN_Multiply,id:6441,x:32641,y:33371,varname:node_6441,prsc:2|A-3989-OUT,B-1436-OUT,C-4057-UVOUT,D-348-OUT;n:type:ShaderForge.SFN_TexCoord,id:4057,x:32959,y:33181,varname:node_4057,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ArcSin,id:348,x:32938,y:33406,varname:node_348,prsc:2|IN-4057-V;proporder:8494-1521-6293;pass:END;sub:END;*/

Shader "Unlit/TestShader" {
    Properties {
        _node_8494 ("node_8494", 2D) = "white" {}
        _TEX_MIP_VAL ("TEX_MIP_VAL", Float ) = 1
        _outline_color ("outline_color", Color) = (0.8490566,0.500623,0.500623,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 100
        Pass {
            Name "Outline"
            Tags {
            }
            Cull Front
            
            CGPROGRAM
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "Tessellation.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma target 5.0
            uniform sampler2D _node_8494; uniform float4 _node_8494_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _outline_color)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float4 projPos : TEXCOORD2;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                float4 _outline_color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _outline_color );
                v.vertex.xyz += float3(_outline_color_var.a,_outline_color_var.a,_outline_color_var.a);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float4 _node_8494_var = tex2Dlod(_node_8494,float4(TRANSFORM_TEX(o.uv0, _node_8494),0.0,o.uv0.g));
                o.pos = UnityObjectToClipPos( float4(v.vertex.xyz + v.normal*_node_8494_var.g,1) );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                float Tessellation(TessVertex v){
                    float4 _node_8494_var = tex2Dlod(_node_8494,float4(TRANSFORM_TEX(v.texcoord0, _node_8494),0.0,v.texcoord0.g));
                    float node_5269 = saturate(( (_node_8494_var.rgb.r*_node_8494_var.r + _node_8494_var.rgb.g*_node_8494_var.g + _node_8494_var.rgb.b*_node_8494_var.b) > 0.5 ? (1.0-(1.0-2.0*((_node_8494_var.rgb.r*_node_8494_var.r + _node_8494_var.rgb.g*_node_8494_var.g + _node_8494_var.rgb.b*_node_8494_var.b)-0.5))*(1.0-partZ)) : (2.0*(_node_8494_var.rgb.r*_node_8494_var.r + _node_8494_var.rgb.g*_node_8494_var.g + _node_8494_var.rgb.b*_node_8494_var.b)*partZ) ));
                    float node_3989 = frac(node_5269);
                    return (node_3989*partZ*v.texcoord0*asin(v.texcoord0.g));
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    
                    // Apply phong tessellation.
                    float4 _outline_color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _outline_color );
                    float phong = _outline_color_var.a;
                    float3 normalz[3];
                    for (int s = 0; s < 3; ++s)
                        normalz[s] = normalize(vi[s].normal);
                    v.vertex = vi[0].vertex * bary.x + vi[1].vertex * bary.y + vi[2].vertex * bary.z;
                    float3 pp[3];
                    for (int i = 0; i < 3; ++i)
                        pp[i] = v.vertex.xyz - normalz[i] * (dot(v.vertex.xyz, normalz[i]) - dot(vi[i].vertex.xyz, normalz[i]));
                    v.vertex.xyz = phong * (pp[0] * bary.x + pp[1] * bary.y + pp[2] * bary.z) + (1.0f - phong) * v.vertex.xyz;
                    
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float4 _outline_color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _outline_color );
                return fixed4(_outline_color_var.rgb,0);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "Tessellation.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma target 5.0
            uniform float4 _LightColor0;
            uniform sampler2D _node_8494; uniform float4 _node_8494_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _outline_color)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 projPos : TEXCOORD3;
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 _outline_color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _outline_color );
                v.vertex.xyz += float3(_outline_color_var.a,_outline_color_var.a,_outline_color_var.a);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                float Tessellation(TessVertex v){
                    float4 _node_8494_var = tex2Dlod(_node_8494,float4(TRANSFORM_TEX(v.texcoord0, _node_8494),0.0,v.texcoord0.g));
                    float node_5269 = saturate(( (_node_8494_var.rgb.r*_node_8494_var.r + _node_8494_var.rgb.g*_node_8494_var.g + _node_8494_var.rgb.b*_node_8494_var.b) > 0.5 ? (1.0-(1.0-2.0*((_node_8494_var.rgb.r*_node_8494_var.r + _node_8494_var.rgb.g*_node_8494_var.g + _node_8494_var.rgb.b*_node_8494_var.b)-0.5))*(1.0-partZ)) : (2.0*(_node_8494_var.rgb.r*_node_8494_var.r + _node_8494_var.rgb.g*_node_8494_var.g + _node_8494_var.rgb.b*_node_8494_var.b)*partZ) ));
                    float node_3989 = frac(node_5269);
                    return (node_3989*partZ*v.texcoord0*asin(v.texcoord0.g));
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    
                    // Apply phong tessellation.
                    float4 _outline_color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _outline_color );
                    float phong = _outline_color_var.a;
                    float3 normalz[3];
                    for (int s = 0; s < 3; ++s)
                        normalz[s] = normalize(vi[s].normal);
                    v.vertex = vi[0].vertex * bary.x + vi[1].vertex * bary.y + vi[2].vertex * bary.z;
                    float3 pp[3];
                    for (int i = 0; i < 3; ++i)
                        pp[i] = v.vertex.xyz - normalz[i] * (dot(v.vertex.xyz, normalz[i]) - dot(vi[i].vertex.xyz, normalz[i]));
                    v.vertex.xyz = phong * (pp[0] * bary.x + pp[1] * bary.y + pp[2] * bary.z) + (1.0f - phong) * v.vertex.xyz;
                    
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float4 _outline_color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _outline_color );
                float3 specularColor = float3(_outline_color_var.r,_outline_color_var.r,_outline_color_var.r);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float4 _node_8494_var = tex2Dlod(_node_8494,float4(TRANSFORM_TEX(i.uv0, _node_8494),0.0,i.uv0.g));
                float node_5269 = saturate(( (_node_8494_var.rgb.r*_node_8494_var.r + _node_8494_var.rgb.g*_node_8494_var.g + _node_8494_var.rgb.b*_node_8494_var.b) > 0.5 ? (1.0-(1.0-2.0*((_node_8494_var.rgb.r*_node_8494_var.r + _node_8494_var.rgb.g*_node_8494_var.g + _node_8494_var.rgb.b*_node_8494_var.b)-0.5))*(1.0-partZ)) : (2.0*(_node_8494_var.rgb.r*_node_8494_var.r + _node_8494_var.rgb.g*_node_8494_var.g + _node_8494_var.rgb.b*_node_8494_var.b)*partZ) ));
                float3 directDiffuse = pow(max( 0.0, NdotL), node_5269) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float node_3989 = frac(node_5269);
                float3 diffuseColor = float3(node_3989,node_3989,node_3989);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = float3(node_5269,node_5269,node_5269);
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                fixed4 finalRGBA = fixed4(finalColor,_node_8494_var.r);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Tessellation.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma target 5.0
            uniform float4 _LightColor0;
            uniform sampler2D _node_8494; uniform float4 _node_8494_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _outline_color)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 projPos : TEXCOORD3;
                LIGHTING_COORDS(4,5)
                UNITY_FOG_COORDS(6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 _outline_color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _outline_color );
                v.vertex.xyz += float3(_outline_color_var.a,_outline_color_var.a,_outline_color_var.a);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                float Tessellation(TessVertex v){
                    float4 _node_8494_var = tex2Dlod(_node_8494,float4(TRANSFORM_TEX(v.texcoord0, _node_8494),0.0,v.texcoord0.g));
                    float node_5269 = saturate(( (_node_8494_var.rgb.r*_node_8494_var.r + _node_8494_var.rgb.g*_node_8494_var.g + _node_8494_var.rgb.b*_node_8494_var.b) > 0.5 ? (1.0-(1.0-2.0*((_node_8494_var.rgb.r*_node_8494_var.r + _node_8494_var.rgb.g*_node_8494_var.g + _node_8494_var.rgb.b*_node_8494_var.b)-0.5))*(1.0-partZ)) : (2.0*(_node_8494_var.rgb.r*_node_8494_var.r + _node_8494_var.rgb.g*_node_8494_var.g + _node_8494_var.rgb.b*_node_8494_var.b)*partZ) ));
                    float node_3989 = frac(node_5269);
                    return (node_3989*partZ*v.texcoord0*asin(v.texcoord0.g));
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    
                    // Apply phong tessellation.
                    float4 _outline_color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _outline_color );
                    float phong = _outline_color_var.a;
                    float3 normalz[3];
                    for (int s = 0; s < 3; ++s)
                        normalz[s] = normalize(vi[s].normal);
                    v.vertex = vi[0].vertex * bary.x + vi[1].vertex * bary.y + vi[2].vertex * bary.z;
                    float3 pp[3];
                    for (int i = 0; i < 3; ++i)
                        pp[i] = v.vertex.xyz - normalz[i] * (dot(v.vertex.xyz, normalz[i]) - dot(vi[i].vertex.xyz, normalz[i]));
                    v.vertex.xyz = phong * (pp[0] * bary.x + pp[1] * bary.y + pp[2] * bary.z) + (1.0f - phong) * v.vertex.xyz;
                    
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float4 _outline_color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _outline_color );
                float3 specularColor = float3(_outline_color_var.r,_outline_color_var.r,_outline_color_var.r);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float4 _node_8494_var = tex2Dlod(_node_8494,float4(TRANSFORM_TEX(i.uv0, _node_8494),0.0,i.uv0.g));
                float node_5269 = saturate(( (_node_8494_var.rgb.r*_node_8494_var.r + _node_8494_var.rgb.g*_node_8494_var.g + _node_8494_var.rgb.b*_node_8494_var.b) > 0.5 ? (1.0-(1.0-2.0*((_node_8494_var.rgb.r*_node_8494_var.r + _node_8494_var.rgb.g*_node_8494_var.g + _node_8494_var.rgb.b*_node_8494_var.b)-0.5))*(1.0-partZ)) : (2.0*(_node_8494_var.rgb.r*_node_8494_var.r + _node_8494_var.rgb.g*_node_8494_var.g + _node_8494_var.rgb.b*_node_8494_var.b)*partZ) ));
                float3 directDiffuse = pow(max( 0.0, NdotL), node_5269) * attenColor;
                float node_3989 = frac(node_5269);
                float3 diffuseColor = float3(node_3989,node_3989,node_3989);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * _node_8494_var.r,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "Tessellation.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma target 5.0
            uniform sampler2D _node_8494; uniform float4 _node_8494_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _outline_color)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float4 projPos : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                float4 _outline_color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _outline_color );
                v.vertex.xyz += float3(_outline_color_var.a,_outline_color_var.a,_outline_color_var.a);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                float Tessellation(TessVertex v){
                    float4 _node_8494_var = tex2Dlod(_node_8494,float4(TRANSFORM_TEX(v.texcoord0, _node_8494),0.0,v.texcoord0.g));
                    float node_5269 = saturate(( (_node_8494_var.rgb.r*_node_8494_var.r + _node_8494_var.rgb.g*_node_8494_var.g + _node_8494_var.rgb.b*_node_8494_var.b) > 0.5 ? (1.0-(1.0-2.0*((_node_8494_var.rgb.r*_node_8494_var.r + _node_8494_var.rgb.g*_node_8494_var.g + _node_8494_var.rgb.b*_node_8494_var.b)-0.5))*(1.0-partZ)) : (2.0*(_node_8494_var.rgb.r*_node_8494_var.r + _node_8494_var.rgb.g*_node_8494_var.g + _node_8494_var.rgb.b*_node_8494_var.b)*partZ) ));
                    float node_3989 = frac(node_5269);
                    return (node_3989*partZ*v.texcoord0*asin(v.texcoord0.g));
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    
                    // Apply phong tessellation.
                    float4 _outline_color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _outline_color );
                    float phong = _outline_color_var.a;
                    float3 normalz[3];
                    for (int s = 0; s < 3; ++s)
                        normalz[s] = normalize(vi[s].normal);
                    v.vertex = vi[0].vertex * bary.x + vi[1].vertex * bary.y + vi[2].vertex * bary.z;
                    float3 pp[3];
                    for (int i = 0; i < 3; ++i)
                        pp[i] = v.vertex.xyz - normalz[i] * (dot(v.vertex.xyz, normalz[i]) - dot(vi[i].vertex.xyz, normalz[i]));
                    v.vertex.xyz = phong * (pp[0] * bary.x + pp[1] * bary.y + pp[2] * bary.z) + (1.0f - phong) * v.vertex.xyz;
                    
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
