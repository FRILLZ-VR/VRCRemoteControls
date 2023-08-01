# VRCMobileController
Guide and scripts for creating a portable controller for world lighting / effects at live events. This controller is hidden from all players not on a whitelist and thus can be carried around your world freely. Examples will use the AudioLinkController prefab object, however this can work with other controllers. 

### Attaching extra controls to the AudioLinkController object

Add your GameObjects (buttons, sliders, etc) as children of the ControlBox.
As an example, I've provided my own setup which adds groups of buttons and a canvas of slider controls.
For instance, "ColorControls" is a GameObject with many buttons as children.

![image](ALControllerPic.png)

Note the Parent Contraint component on the ControlBox child of the AudioLinkController. This component will always take the Handle object as its source transform. Any buttons or sliders you attach by adding a child to the ControlBox will need the same setup. I recommend grouping your controls this way to avoid adding ParentConstraint components to each button or canvas you may need to add.

As an example above, "ColorControls" is a GameObject that holds many buttons as children. Only the top parent, "ColorControls" will need the ParentConstraint component on it to be locked to the rest of the controller.

Once everything is placed in your preferred position, the constraint setting needs to be enabled to "Lock" for each parent that has this component.

![image](parentConstraint.png)

### Using the hide script
At this point you should be able to add the [provided script](https://github.com/FRILLZ-VR/VRCMobileController/blob/main/LocalHideUIWhitelist.cs) into your project.  I recommend right clicking in your unity asset folder and choosing "Create new U# script", and then pasting the provided code in its entirety.

This script hides all meshes, canvases, and colliders for everyone except those permitted on the whitelist. It is independent of the controller and can be placed on any object in the scene, preferbaly an empty GameObject. Simply drag your elements to each group and provide the VRC usernames of who you would like to be able to see the controller. 

Since no game objects are toggled off completely, all scripts should behave as normal for your buttons and sliders for everyone else as long as they are global. Non whitelisted users will not be able to see or interact with the controller.

In this example, I'll be dragging in the mesh components from the AudioLinkController, as well as my own buttons and their respective colliders and two canvas elements:

![image](LocalUIScriptPic.png)

The controller I use has many extra controls for my world. You should be able to use any variety of button or slider prefabs and get similar results.

![image](controllerFinal.png)

## Optional: Teleport Controller to position
Add the [controller reset](https://github.com/FRILLZ-VR/VRCMobileController/blob/main/ControllerPositionReset.cs) script to any cube or object with a collider for interaction. Provide whitelist names like before, and then fill the references from the AudioLinkController (This will be dragged twice for the VRC Object Sync reference, as well as the VRC Pickup reference). 

Add the position/rotation you would like the controller to be reset to below, and this will teleport the controller to the location globally for everyone. Useful if it gets lost or you have a large map!

![image](teleport.png)

**Notes**
- Your connected sliders/buttons should be on the "Pickup" layer in Unity to avoid player collision.
