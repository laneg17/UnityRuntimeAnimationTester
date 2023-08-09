using UnityEngine;
using System.Collections;


//By Lane Gingras
//File name: Animation_Tester.cs
//Created on: August 7, 2023


public class Animation_Tester : MonoBehaviour
{
    //Instructions visible in the inspector
    [TextArea]
    public string INSTRUCTIONS = "During Runtime: In Game View press the Up and Down arrow keys to change the selected Animation\nDuring Runtime: In Game View press P key to play the animation (or select Loop Animation)";

    //Used to show currently selected animation in the inspector
    [TextArea]
    public string currentAnimation = "";

    //User inputs how many animations they need to test and their name. If the array is left at 0 on launch there will be a warning, and if they attempt to test an animation there will be an error message telling them to input an animation name in this array
    [Tooltip("Enter how many animations you need to test and enter their individual names into the array")]
    public string[] animationNames;

    //When this bool is enabled then the selected animation will play automatically and loop until disabled
    [Tooltip("If enabled then selected animation will play automatically and loop")]
    public bool loopAnimation;

    private Animation anima; //the legacy animation component attached to the gameobject being tested
    private int position; //current position in the animation array list
    private int positionLimit; //maximum position the animation array list can be moved up to

    // Start is called before the first frame update
    void Start()
    {
        //instructions posted to the console, spits a warning if animation names array is still at 0 on launch
        if (animationNames.Length > 0)
        {
            Debug.Log("Click and Read Me!\n\nThis is an Animation Tester.\n\nDuring Runtime: In Game View press the Up and Down arrow keys to change the selected Animation\nDuring Runtime: In Game View press P key to play the animation\nEnable/Disable Loop Animation in Inspector\n\nSelected Animation: " + animationNames[position] + "\n\n" + "Created by Lane Gingras\n");
        }
        else if (animationNames.Length == 0 && this.gameObject.GetComponent<Animation>() != null)
        {
            Debug.Log("Click and Read Me!\n\nThis is an Animation Tester.\n\nDuring Runtime: In Game View press the Up and Down arrow keys to change the selected Animation\nDuring Runtime: In Game View press P key to play the animation\nEnable/Disable Loop Animation in Inspector\n\nCreated by Lane Gingras\n");
            Debug.Log("<color=yellow>Warning: </color>Animation Names array is empty.\n\n");
        }
        else//if animation component is missing from model
        {
            Debug.Log("Click and Read Me!\n\nThis is an Animation Tester.\n\nDuring Runtime: In Game View press the Up and Down arrow keys to change the selected Animation\nDuring Runtime: In Game View press P key to play the animation\nEnable/Disable Loop Animation in Inspector\n\nCreated by Lane Gingras\n");
        }    

        //initialization, grabs the objects animation, sets the default array position to 0 
        position = 0;
        
        //Grabs Animation component from model, if not found it throws an error
        if (this.gameObject.GetComponent<Animation>() != null)
        {
            anima = this.gameObject.GetComponent<Animation>();
        }    
        else
        {
            Debug.Log("<color=red>Error: </color>No 'Animation' component found on GameObject, program will not work. Please ensure model is marked as using Animation Type 'Legacy' in the Rig section of the Import settings.\n\n");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<Animation>() != null)//Ensures the animation component still exists
        {
            //Debug.Log(position);
            //Debug.Log(positionLimit);

            //Updates the reference variable for the size of the array. This is used to make sure the user can't change the position to be out of bounds on the upper end of the array. This along with some other pieces of code also enables the user to add/remove animations on the fly during runtime
            positionLimit = animationNames.Length;

            //If the animation names array has enough entries removed so that the referenced position doesn't exist anymore then it is changed to the positionLimit (or current animation names array size) - 1
            if (position == positionLimit && animationNames.Length > 0)
            {
                position = positionLimit - 1;
            }

            //Used to update the inspector note variable informing the user of the current animation selected
            if (animationNames.Length > 0)
            {
                currentAnimation = "Animation = '" + animationNames[position] + "' " + "(" + position + ")";
            }
            else
            {
                currentAnimation = "* Animation Names array is empty *";
            }



            //Input for user to change the currently selected array position using the arrow keys. Also updates inspector note and console showing newly selected animation
            if ((Input.GetKeyDown("down")) && (position != 0) && (animationNames.Length > 0))
            {
                position -= 1;
                currentAnimation = "Animation = " + animationNames[position] + " (" + position + ")";
                Debug.Log("Animation = " + animationNames[position] + " (" + position + ")");
            }
            else if (Input.GetKeyDown("up") && (positionLimit != position + 1) && (positionLimit > 1) && (animationNames.Length > 0))
            {
                position += 1;
                currentAnimation = "Animation = " + animationNames[position] + " (" + position + ")";
                Debug.Log("Animation: = " + animationNames[position] + " (" + position + ")");
            }


            //Animation playing (both for user input P and loop animation) is handled here
            if (loopAnimation == true && (animationNames.Length > 0) && animationNames[position] != "")//Loop Animation
            {
                anima.Play(animationNames[position]);

                if (anima.IsPlaying(animationNames[position]) == false)//Debug, throws error and disables loop animation if name in currently selected animation is blank
                {
                    loopAnimation = false;
                    Debug.Log("<color=red>Error: </color>Animation name not found. Disabling Loop Animation.\n\n");
                }
            }
            else if (Input.GetKeyDown("p") && (animationNames.Length > 0) && animationNames[position] != "")//User Input P
            {
                anima.Play(animationNames[position]);
            }
            

            //Error testing
            if (Input.GetKeyDown("p") && animationNames.Length == 0)//Debug, if user presses P but the Animation Names array is not declared (has 0 positions)
            {
                Debug.Log("<color=red>Error: </color>Animation Names array is empty.\n\n");
            }
            else if (loopAnimation == true && animationNames.Length == 0)//Debug, if user enables Loop Animation but the Animation Names array is not declared (has 0 positions). Disables Loop Animation
            {
                Debug.Log("<color=red>Error: </color>Animation Names array is empty. Disabling Loop Animation.\n\n");
                loopAnimation = false;
            }
            else if ((loopAnimation == true) && (animationNames.Length > 0) && (animationNames[position] == ""))//Debug, if user enables Loop Animation but the selected Animation is empty (doesn't have a name, is blank). Disables Loop Animation
            {
                loopAnimation = false;
                Debug.Log("<color=red>Error: </color>Animation name cannot be blank. Disabling Loop Animation.\n\n");
            }
        }
        else if (this.gameObject.GetComponent<Animation>() == null && loopAnimation == true)//Debug, if the animation component can't be found and the user selects Loop Animation then this throws an error and disables Loop Animation
        {
            loopAnimation = false;
            Debug.Log("<color=red>Error: </color>No 'Animation' component found on GameObject. Disabling Loop Animation.\n\n");
        }
    }
}