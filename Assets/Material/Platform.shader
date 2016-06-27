Shader "Custom/Platform" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)

	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		pass{
			CGPROGRAM
			// Physically based Standard lighting model, and enable shadows on all light types
			#pragma vertex vert 
			#pragma fragment frag
			// Use shader model 3.0 target, to get nicer looking lighting
			fixed4 _Color;

			struct Input{
				float4 pos:POSITION;
			};
			struct v2f{
				float4 pos:POSITION;
			};

			v2f vert(Input i){
				v2f v;
				v.pos = mul(UNITY_MATRIX_MVP,i.pos);
				return v;
			}

			fixed4 frag(v2f v):COLOR
			{
				return _Color;
			}

			ENDCG
		}
	}
	FallBack "Diffuse"
}
