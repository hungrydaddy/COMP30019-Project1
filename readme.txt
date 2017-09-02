# COMP30019 Project1 submission

Diamond Square Algorithm sourced from Youtube resources:
https://www.youtube.com/watch?v=1HV8GbFnCik&t=300s
Detailed Comment has been written to prove for understanding.



Ground Shader excerpted and modified from:
https://en.wikibooks.org/wiki/GLSL_Programming/Blender/Smooth_Specular_Highlights#Per-Pixel_Lighting_.28Phong_Shading.29






We generated the terrain by using different layers of functionalities. 

First of all, we implemented the camera motions to enable the users to move around and rotate in “flight mode”. The implementation of the camera mainly consists of the keyboard part, which detects key inputs, and the mouse part, which detects movements of mouse and translates that into angles to rotate around the corresponding local axis. 

Secondly, for the mesh, we applied the diamond-square algorithm to generate the mesh. The implementation was adapted and modified from the reference above. We randomised the height for the corners and then apply the algorithm. To ensure that the terrain is not plain, we made sure there is at least 1 low point and 1 high point among the corners.

Lastly, we spent many hours to figure out the shader. It was also adapted from above. We applied a layer of Phong illumination model to the surface of the terrain.

Apart from the adapted sources, everything else has been done by ourselves.