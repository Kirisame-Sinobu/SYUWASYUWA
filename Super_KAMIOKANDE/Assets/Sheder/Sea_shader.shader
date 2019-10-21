Shader "Custom/Sea_shader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Wave_scale ("Wave scale", float) = 25
        _Wave_depth("Wave depth",Range(0,1)) = 0.1
       [MaterialToggle]_Wave_side("Wave side",int) = 0
       _Wave_speed("Wave speed",float) = 5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        Pass{
            CGPROGRAM
                    #pragma vertex vert
                    #pragma fragment frag
                    #pragma multi_compile_fog
                    
                    #include "UnityCG.cginc"

                    #define PI 3.141592


            struct appdata {
               float4 vertex : POSITION;
               float2 uv : TEXCOORD0;
            };

            struct v2f {
               float4 vertex : SV_POSITION;
               half2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            half _Glossiness;
            fixed4 _Color;
            float _Wave_scale;
            float _Wave_depth;
            int _Wave_side;
            float _Wave_speed;


            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {

            fixed2 main_uv = i.uv;

             //画像の移動をしている
             // half move_x = abs(sin(_Time.x * _Wave_speed));
              half move_x = _Time.x * _Wave_speed;
              move_x = frac(move_x);

            //  half2x2 move_matrix = half2x2(1 + move_x,0,0,1); 
             // i.uv = mul(i.uv,move_matrix);
             i.uv.x = i.uv.x + move_x;
              if(i.uv.x > 1){
              i.uv.x = frac(i.uv.x);
              }
              fixed4 col = tex2D(_MainTex,i.uv);

            //縞模様を表示
              col = tex2D(_MainTex, i.uv);
              float wave;
              if(_Wave_side == 0){
              wave = sin(_Wave_scale * main_uv.x - sin(10 * main_uv.y) + _Time.x*_Wave_speed*10);
              }else{
              wave = sin(_Wave_scale * main_uv.y - sin(10 * main_uv.x) + _Time.x*_Wave_speed*10);
              }


              fixed4 final_col = _Wave_depth * fixed4(wave,0,0,1) + col;
             // if(main_uv.x > frac(_Time.x)){
             // final_col = fixed4(0,0,0,1);
             // }
              return final_col;
            }
                ENDCG     
        }
    }
}
