Shader "Test/Default" {
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
			};

			struct v2f {
					float4 pos : SV_POSITION;
			};

			v2f vert(a2v v) {
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				return o;
			}

			fixed4 frag(v2f i) : SV_Target{
				return _MainColor;
			}

			ENDCG
		}
	}

}
