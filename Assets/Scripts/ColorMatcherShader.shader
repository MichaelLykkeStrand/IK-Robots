Shader "Custom/ColorMatcherShader" {
	Properties {
		_PalText ("", 2D) = "white" {}
	 	_MainTex ("", 2D) = "white" {}
	}

	SubShader {
		Lighting Off
		ZTest Always
		Cull Off
		ZWrite Off
		Fog { Mode Off }

	 	Pass {
	  		CGPROGRAM
			// Upgrade NOTE: excluded shader from DX11, Xbox360, OpenGL ES 2.0 because it uses unsized arrays
	  		#pragma exclude_renderers flash
	  		#pragma vertex vert_img
	  		#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest
	  		#include "UnityCG.cginc"

			uniform fixed4 _Colors[256];
	  		uniform sampler2D _MainTex;
			uniform sampler2D _PalText;
			
	  		fixed4 frag (v2f_img i) : COLOR
	  		{
				float4 baseCol = tex2D(_MainTex, i.uv);
				float4 bestColor = float4(0, 0, 0, 0);
				float3 bestDiff = float3(1000, 1000, 1000);
				for (float i = 0; i < 32 /*number of colors in palette*/; ++i) {
					float4 palCol = tex2D(_PalText, float2(i, 0));
					float3 diff = abs(tex2D(_PalText, i).r - baseCol.r) + abs(tex2D(_PalText, i).g - baseCol.g) + abs(tex2D(_PalText, i).b - baseCol.b);
					if (length(diff) < length(bestDiff)) {
						bestDiff = diff;
						bestColor = palCol;
					}
				}
				return bestColor;
	  		}
	  		ENDCG
	 	}
	}

	FallBack "Diffuse"
}
