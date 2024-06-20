                #include "UnityCG.cginc"
                #include "Lighting.cginc" 
                #include "AutoLight.cginc"

               #define USE_LIGHTING
               #define TAU 6.28318530718


                struct MeshData
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;//xyz = tan dir, w = tan sign
                };

                struct Interpolators
                {
                    float2 uv : TEXCOORD0;
                    float3 normal : TEXCOORD1;
                    float3 tangent : TEXCOORD2;
                    float3 bitangent : TEXCOORD3;
                    UNITY_FOG_COORDS(1)
                    float4 vertex : SV_POSITION;
                    float3 wPos : TEXCOORD4;
                    //float3 wPos : TEXCOORD3;
                    //float3 wPos : TEXCOORD4;
                    //float4 _color : COLOR;
                    LIGHTING_COORDS(5,6)
                };

                sampler2D _RockAlbedo;
                sampler2D _RockNormals;
                sampler2D _RockHeight;
                sampler2D _DiffuseIBL;
                sampler2D _SpecularIBL;
                float4 _RockAlbedo_ST;
                float _Gloss;
                float4 _Color;
                float4 _AmbientLight;
                float _NormalIntensity;
                float _DisplacementStrength;


                float2 Rotate(float2 v, float angRad){
                    float ca = cos(angRad);
                    float sa = sin(angRad);
                    return float2(ca * v.x - sa * v.y, sa * v.x - ca * v.y);
                }

               float2 DirToRectilinear( float3 dir ){

                    float x = atan2( dir.z, dir.x ) / TAU + 0.5;//-tau/2 tau/2,,,, 0-1 így
                    float y = dir.y * 0.5 + 0.5;//0-100

                    return float2(x,y);

                }


                Interpolators vert (MeshData v)
                {
                    Interpolators o;

                    o.uv = TRANSFORM_TEX(v.uv, _RockAlbedo);

                    float heights = tex2Dlod(_RockHeight, float4(o.uv,0,0)).x * 2 - 1;

                    

                    v.vertex.xyz += v.normal * (heights  * _DisplacementStrength);


                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.normal = UnityObjectToWorldNormal(v.normal); 
                    o.tangent = UnityObjectToWorldDir( v.tangent.xyz);
                    o.bitangent = cross(o.normal, o.tangent);
                    o.bitangent *= (v.tangent.w * unity_WorldTransformParams.w);//correctly handling flipping and mirroring
                    o.wPos = mul(unity_ObjectToWorld, v.vertex);
                                   


                    TRANSFER_VERTEX_TO_FRAGMENT(o);//lightning akcsually xD

                    return o;
                }

                float4 frag (Interpolators i) : SV_Target
                {

                   
                    float3 V = normalize(_WorldSpaceCameraPos - i.wPos);
/*
                   
                    #ifdef IF_IS_IN_BASE_PASS

                        float3 viewRefl = reflect( , -V, i.normal );

                        float3 specIBL = tex2Dlod( _SpecularIBL, DirToRectilinear(viewRefl)).xyz;



                        return float4(specIBL,0);
                    #else
                        return float4(0,0,0,0);
                    #endif
                    
                    */





                    float3 roock =  tex2D(_RockAlbedo, i.uv);
                    float3 surfaceColor = roock * _Color.rgb;

                    float3 tanSpaceNormal = UnpackNormal(tex2D(_RockNormals, i.uv) );

                    tanSpaceNormal = normalize(lerp(float3(0,0,1), tanSpaceNormal, _NormalIntensity));

                    

                    float3x3 mtxTanToWorld = {
                        i.tangent.x, i.bitangent.x, i.normal.x,
                        i.tangent.y, i.bitangent.y, i.normal.y,
                        i.tangent.z, i.bitangent.z, i.normal.z
                    };

                    float3 norm = mul(mtxTanToWorld, tanSpaceNormal);

                    

                    #ifdef USE_LIGHTING
                         //diffuse Lightning
                       // float3 norm = normalize(i.normal);
                        float3 l = normalize(UnityWorldSpaceLightDir(i.wPos));//a direction
                        float attenuation = LIGHT_ATTENUATION(i);
                        float3 lambert = saturate(dot(norm,l));
                        float diffuseLight = (lambert * attenuation) * _LightColor0.xyz;
                        
                        #ifdef IF_IS_IN_BASE_PASS
                         //   float3 diffuseIBL = tex2Dlod( _DiffuseIBL, DirToRectilinear(l)).xyz;
                          //  diffuseLight += diffuseIBL;// _AmbientLight;//Adds the indirect diffuse Lighting
                        #endif
                        
                        //return float4(diffuseLight.xxx,1);

                        //SPECULAR Lighting
                       // float3 R = reflect(-l,norm); just used for simply phone
                        float3 H = normalize(l+V);
                        float3 SpecLight = saturate(dot(H,norm))*(lambert > 0);//blin phong

                      //  float3 BlinnPhong = dot(H, norm);
                     //   BlinnPhong = pow(BlinnPhong, _Gloss);

                        float specularExponent = exp2(_Gloss * 11) + 2;



                        SpecLight = pow(SpecLight, specularExponent) * _Gloss * attenuation;//specular exponent, gloss
                        SpecLight *= _LightColor0.xyz;



                        float fresnel = 1-step(0.5,dot(V, norm));//*(frac(_Time.y * 2));//fresnel glow effect
                        //return fresnel*_Fresnel;
                        return float4(diffuseLight * surfaceColor + SpecLight,1);//metallic -> multiply
                    #else
                        #ifdef IF_IS_IN_BASE_PASS
                            return surfaceColor;
                        #else
                            return 0;
                        #endif
                    #endif
                  //  return i._color;
               
                   //the specLight as well, if only diffuse light got multiplied it will be more plastic

                    // sample the texture
                    //fixed4 col = tex2D(_MainTex, i.uv);
                    // apply fog
                  //  UNITY_APPLY_FOG(i.fogCoord, col);
                   // return col;
                   }