# UnityRuntimeAnimationTester
Quickly and simply test animations in Unity during runtime.

**Using the Tool**
1. Ensure the object that is being tested has it's rig set to "Legacy" in the model import settings
2. Put your object into the scene
3. Attach the "AnimationTester" script to the object
4. Set "Animation Names" array (list) to desired size, enter the names of the animation clips you wish to test in the created fields
5. Optionaly enable "Loop Animation" in the Inspector to make the selected animation play automatically and loop
6. Run the scene, in game view use Up and Down Arrow keys to change selected animation
7. Press the P key to play the currently selected animation (if Loop Animation is enabled animation will automatically play)

**Features**
- Unity Package includes example animated character with scene set up
- Easy Game View controls, arrow keys to cycle through animations and P key to play
- Loop Animation feature that loops selected animation
- Dynamically add or remove animation clip names to the list during runtime
