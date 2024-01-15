# Godot 4 ray cast showcase
Project showcasing [ray casting](https://docs.godotengine.org/en/stable/tutorials/physics/ray-casting.html) in Godot 4.

[Camera controls are the same as the editors](https://github.com/jkvastad/godot-4-editor-camera-controls). 

Note the output logs as you click on different things:
 * The PanelContainer "ControlBox" blocks the [input events](https://docs.godotengine.org/en/stable/tutorials/inputs/inputevent.html) but not the polled raycasts.
 * Only the first 3D Blocks are hit by both the event and the polling raycast.
 * You can hit both the 2D area and the 3D blocks with one click - [they are technically different raycasts in the viewports World2D/World3d](https://docs.godotengine.org/en/stable/tutorials/rendering/viewports.html#worlds).
 * You can hit multiple 2D areas with one click - similar to the [intersect_point](https://docs.godotengine.org/en/stable/classes/class_physicsdirectspacestate2d.html#class-physicsdirectspacestate2d-method-intersect-point) method.

![image](https://github.com/jkvastad/godot-4-raycast-event-vs-polling/assets/9295196/847711dc-107f-412c-94a4-899eaa95815c)
