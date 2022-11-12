=== THANKS ===

Thank YOU so much for supporting a fellow developer just like you by purchasing this asset! Please feel free to follow me on Twitter - @DomFeargrieve
Special thanks to my wonderful wife Vix and loyal pup Ozzy <3

=== CREDIT & LEGAL ===

This asset is provided as is under the Unity Technologies Asset Store EULA. Credit is not required to be given for any commercial product usage of this package however if you would like to, credit would be much appreciated as "Dominic Feargrieve - https://feargrieve.dev". Please include both name AND website URL. 

=== COMPATIBILITY ===

This asset has been developed and tested on Unity version 2020.3.32f1 but should work with any URP compatible Unity editor version. It is URP compatible ONLY and has been verified with 10.8.1 and with Shader Graph version 10.8.1. Your mileage may vary with newer or older versions of URP and Shader Graph and guarantee CANNOT be given for how well the asset works with later iterations of Unity, URP or Shader Graph.

=== SETUP ===

1. Open up the 'DEMOScene' folder and the scene within and press the Play button
2. This is an example of how the shader can be used, stop Unity and in the scene view open the 'Cauldron' game object then navigate to the child object 'Cauldron' then the child object 'PotionPlane'.
3. Access the properties on the 'potionMat' material and notice the shader assigned 'potionPBR' - this is the core of the asset and the variables exposed in the shader are the aspects which can be customised to your needs.
	a. MainColor - The color the potion surface will have, HDR available.
	b. BubbleRingColor - The color the bubble rings which appear on the potion surface will have, HDR available.
	c. MaskWidth - The width of the alpha mask which keeps the potion visible on the plane within the diamter of the open cauldron.
	d. MaskHeight - The height of the alpha mask which keeps the potion visible on the plane within the diamter of the open cauldron.
	e. MaskOffset - The XY coordinates for where the alpha mask is centered on the plane. The center is -0.5, -0.5.
	f. Tiling - Controls the tiling amount of the bubble rings.
	g. Speed - The speed at which the bubble rings animate.
	h. SurfaceTexture - The texture sampled for the surface of the potion liquid.
	i. SurfaceTextureTiling - Controls the tiling amount of the surface texture.
	j. ReflectionAmount - Determines how reflective the potion is of the environment.
	k. SurfaceTextureTiling2 - Controls the tiling amount of the second sampled surface texture.
	l. TexTilingSpeed1 - Controls the speed at which the first sampled surface texture is animated.
	m. TexTilingSpeed2 - Controls the speed at which the second sampled surface texture is animated. Keep this at a negative value to run contrary to the first texture sample.
	n. RenderTexTiling - Controls the tiling amount for the render texture which samples the main camera view to provide the planar reflections.
	o. RenderTexOffset - Controls the offset amount for the render texture which samples the main camera view to provide the planar reflections.
	p. NormalStrength - The strength of the liquid surface normal map from surface texture.
	q. NormalOffset - The offset of the liquid surface normal map from surface texture.
	r. Scale - The scale of the noise providing distortion of reflections on the liquid.
	s. TimeMulti - The time multiplier controlling the speed of the noise distortion animation speed.
	t. NoiseStrength - The overall power of the distortion effect.
	u. Metallic - The metallic level of the material.
	v. Smoothness - The smoothness level of the material. 
	w. Occ - The occlusion level of the material. 
	x. TilingSpeed - The rate at which the surface vertex displacement is animated.
	y. NormalTiling - Controls the tiling of the height map being sampled for surface vertex displacement. 
	z. HeightMap - The noise texture which is being sampled to provide surface vertex displacement. 
	aa. DispStrength - Controls the amount by which the surface vertices are displaced.
	ab. SwirlNoiseMulti - The rate at which a twirl noise effect is animated.
	ac. SwirlStrength - The overall power of the twirl noise effect.
	ad. SwirlNoiseTex - The noise texture which is sampled to provide a swirl effect.
	ae. SwirlTiling - Controls the tiling of the noise texture which is sampled to provide a swirl effect.
	af. SwirlFresnel - The power of the fresnel effect applied to the swirl effect.
	ag. SwirlColor - The color of the swirl effect, HDR available.
4. Notice within the same 'Cauldron' child object is another child object named 'Fire'. Expand the child objects and access the properties on the 'fireMat' material and notice the shader assigned 'fire' - this is an additional shader for the campfire flames visual effect. The variables exposed in the shader are the aspects which can also be customised to your needs.
	a. Noise - The noise textue being sampled to provide the flames.
	b. Speed - The rate at which the flames are animated.
	c. NoiseTiling - Controls the tiling amount for the noise texture.
	d. Distortion - The texture being sampled to provide a distortion effect to the flames.
	e. DistortionSpeed - The rate at which the distortion effect is animated.
	f. DistortionTiling - Controls the tiling amount for the distortion texture.
	g. EffectsStrength - The overall power of the effect. 
	h. Step - A parameter controlling the Edge value of the step node, controls the sharpness of the effect as it is applied on the Y axis.
	i. Smoothstep - A parameter controlling the split of the sphere object's UVs, raises and lowers the flames on the Y axis.
	j. Color1 - The first color being sampled in a lerp node, HDR available.
	k. Color2 - The second color being sampled in a lerp node, HDR available.
	l. ColorRamp - Values controlling a smoothstep controlling the split of the sphere objects UV's in regard to where colour is applied to the flames.
5. Notice within the same 'Cauldron' child object is another child object named 'BubblesParticles'. Expand the child object and access the Renderer component of the particle system and then the 'particleBubbleMat' material and notice the shader assigned 'particleBubblePBR' - this is another shader for the popping bubbles on the surface of the potion. The variables exposed in the shader are the aspects which can, again, be customised to your needs.
	a. NoiseScale - The scale amount of the noise generated for the bubble's animated distortion effect.
	b. lerpA - The A value of the lerp node which controls the alpha dissolve of the bubble.
	c. lerpB - The B value of the lerp node which controls the alpha dissolve of the bubble.
	d. NoiseTexture - The noise texture being sampled to provide a swirl effect on the bubble surface.
	e. TexTiling - Controls the tiling amount of the above noise texture.
	f. Color - The color the bubble will have, HDR available. 
	g. Tex1Speed - Controls the speed at which the first sampled noise texture is animated.
	h. Tex2Speed - Controls the speed at which the second sampled noise texture is animated. Keep this at a negative value to run contrary to the first texture sample.
	i. Color2 - The color of the edge around the bubble, HDR available.
	j. StepVector - Controls the thickness of the edge given to the outside of the bubble, driven by a fresnel effect.

=== SUPPORT ===

Any questions, feedback or issues can be reported to: domfeargrieve@gmail.com
I will do my best to reply in a timely manner but no assurance is given to the speed of the reply.

v1.0.0
Apr 2022