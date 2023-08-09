# UnityRuntimeAnimationTester
Quickly and simply test animations in Unity during runtime.

**Features**
- Unity Package includes example animated character with scene set up
- Easy Game View controls, arrow keys to cycle through animations and P key to play
- Loop Animation feature that loops selected animation
- Dynamically add or remove animation clip names to the list during runtime

**Using the Tool**
1. Import your model, set up your animation clips, *ensure the rig is set to 'Legacy' in the import settings*
![Alt text](/Images/LaneGingras_UnityTool_1.png?raw=true "Cover")

2. Add your model to the scene, attach the "AnimationTester" script to the part of the model that has the 'Animation' component
![Alt text](/Images/LaneGingras_UnityTool_2.png?raw=true "Cover")

3. Set "Animation Names" array (list) to desired size, then enter the names of the animation clips you wish to test in the created fields
![Alt text](/Images/LaneGingras_UnityTool_3.png?raw=true "Cover")

4. Optionaly enable "Loop Animation" in the Inspector to make the selected animation play automatically and loop
![Alt text](/Images/LaneGingras_UnityTool_4.png?raw=true "Cover")

5. Run the scene, in game view use the Up and Down Arrow keys to change selected animation
6. Press the P key to play the currently selected animation (if Loop Animation is enabled in the Inspector then animation will automatically play)
![Alt text](/Images/LaneGingras_UnityTool_5.png?raw=true "Cover")
