# VRCMobileController
Guide and scripts for creating a portable controller for world lighting / effects at live events. Examples will use the AudioLinkController prefab object, however this can work with other controllers. 

### Attaching extra controls to the AudioLinkController object

Add your GameObjects (buttons, sliders, etc) as children of the ControlBox.
As an example, I've provided my own setup which adds groups of buttons and a canvas of slider controls.

![image](https://github.com/FRILLZ-VR/VRCMobileController/assets/60633555/e74a6848-5b58-4859-87fd-cfba61382c65)

Note the Parent Contraint component on the ControlBox child of the AudioLinkController. This component will always take the Handle object as its source transform. Any buttons or sliders you attach by adding a child to this object will need the same setup. Once placed in your preferred position, the constraint setting needs to be enabled to "Lock".

![image](https://github.com/FRILLZ-VR/VRCMobileController/assets/60633555/41bc9320-33a4-4c07-8c95-bb62b4be8284)

### Using the hide script
At this point you should be able to add the provided script into your project. I recommend right clicking in your unity asset folder and choosing "Create new U# script", and then pasting the provided code.

This script hides all meshes, canvases, and colliders for everyone except those permitted on the whitelist. It is independent of the controller and can be placed on any object in the scene, preferbaly an empty GameObject. Simply drag your elements to each group and provide the VRC usernames of who you would like to be able to see the controller. Since no game objects are toggled off, all scripts should behave as normal for your buttons, and sliders, for everyone else, however non whitelisted users will not be able to see or interact with the controller.

In this example, I'll be dragging in the mesh components from the AudioLinkController, as well as my own buttons and their respective colliders and two canvas elements:

![image](https://github.com/FRILLZ-VR/VRCMobileController/assets/60633555/57b021b6-0042-4786-9f01-6b4438647fad)

The controller in question has many extra controls for my world. You may use any button or slider prefab you prefer.

![image](https://github.com/FRILLZ-VR/VRCMobileController/assets/60633555/d2496fb3-6d04-4cec-a144-8ca55208fcbc)

