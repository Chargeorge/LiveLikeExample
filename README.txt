Example Readme


This code is an example of a event and trigger system for Unity.

It's built from the groundup with all my own code.  

IT has three parts, 

Condition
Trigger
Effect

Conditions are custom written and look for specific triggers, this.  The code that handles all of the trigger state is in GenericTrigger.cs, and each individual trigger can have custom code if need be, but none was needed for this example.  Effects are re-usable chunks that cause a behavior.  This example has effects to play a sound, cause a jump or change color.  

The system is flexible and allows triggers to effect other gameobjects in the scene, and the effets are easily reusable, with exposed variables.  The conditions are seperated from the camera to allow other elements in the scene to use them (EG, an NPC in the scene may use the raycastcondition to effect the world.)

I also explored using Unity's built in event system for this, but I felt like it was not in the spirit of the test.  I have that code if you wish to see how it would work.

Thanks!