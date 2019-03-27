Shader "Test/Default1" {
	//逐顶点漫反射
	Properties{
		_MainColor("Main Color", Color) = (1, 1, 1, 1)
	}

	SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 150
		Pass {
			Tags { "LightMode" = "ForwardBase" "Queue" = "Geometry" }
			CGPROGRAM


			#pragma vertex vert
			#pragma fragment frag

			#include "Lighting.cginc"

			fixed4 _MainColor;

			struct a2v {
				float4 vertex : POSITION;
				float4 color : COLOR;
			};

			struct v2f {
				float4 pos : SV_POSITION;
				fixed4 vertex_color : TEXCOORD0;
			};

			v2f vert(a2v v) {
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.vertex_color = v.color;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target{
				return i.vertex_color;
			}

			ENDCG
		}
	}

}
