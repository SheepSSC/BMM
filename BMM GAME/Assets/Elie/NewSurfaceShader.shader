Shader "Custom/NewSurfaceShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        
        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf(Input IN, inout SurfaceOutput o) 
        {
			const float3 ColorToReplace = float3(1, 1, 1); // black
			const float3 NewColor = _Color;

			// read pixel from texture
			half4 c = tex2D(_MainTex, IN.uv_MainTex);

			// check if pixel from texture is close to ColorToReplace
			float isColorToReplace = step(0.001, dot(c.rgb, ColorToReplace));

			// either use NewColor or the old color, depending whether isColorToReplace is 0 or 1
			c.rgb = isColorToReplace * NewColor + (1 - isColorToReplace) * c.rgb;

			o.Albedo = c.rgb;
			o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
