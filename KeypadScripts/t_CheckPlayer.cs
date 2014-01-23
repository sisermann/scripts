using UnityEngine;
using System.Collections;

public class t_CheckPlayer : MonoBehaviour 
{
	// Reference to the player.
	public GameObject player;
	
	public GameObject door_PASSIVE;
	public GameObject door_PASSIVE_collider;
	public GameObject doorAndKeypad_ACTIVE;
	public GameObject theSelector;
	
	public GUIText thisText;
	
	public int iteratorLock = 0;
	
	public int gamepadB_press_count = 0;
	
	private Vector3 doorRotation = new Vector3(0.0f,96.80025f,0.0f);
	
	internal OpenDoor theDoor;
	
	public bool quest_solved;
	
	private KeypadControlScript keypad;
		
	void Awake ()
	{
		// Setting up the reference.
		//player = GameObject.FindGameObjectWithTag(Tags.player);
					
	}
	
	void OnTriggerEnter (Collider other)
	{
		// Message for Player to Enter Input-Mode
		thisText.text = "Press B for Keypad-Access";
		
	}
	
	void OnTriggerStay (Collider other)
	{	
		// Checking if "B" was pressed and initializing all the things so that
		// the player is ready to control shit on the keypad, but does not move away
		// when it 
		if(Input.GetButtonDown("Fire2"))
		{
			//turn off the players ability to move with the gamepad ...
			player.GetComponent<OVRGamepadController>().enabled = false;
			
			//useless ...
			gamepadB_press_count++;
			
			//activates the Selection Object that is a box hovering over the keypads buttons 
			//it is called 'buttonSelector' in the SceneGraph
			theSelector.SetActive(true);
			
			//note for the player that informs it to press the 'B' key again to exit keypad mode
			thisText.text = "Press B again for Exit";
			
		}
		
		//Checks if the 'B' Button on the gamepad was pressed so the player can exit the 
		//Keypad-Access mode
		if(gamepadB_press_count > 5)
		{
			player.GetComponent<OVRGamepadController>().enabled = true;
			theSelector.SetActive(false);
		}
		
		
		// If the colliding gameobject is the player...
		if(other.gameObject == player)
		{	
			//activates the active Game Objects with scripts on it
			doorAndKeypad_ACTIVE.SetActive(true);
			door_PASSIVE.SetActive(false);
			
			theDoor = GameObject.FindGameObjectWithTag(Tags.door).GetComponent<OpenDoor>();
			quest_solved = theDoor.doorIsOpen;
		}
		
		
		//checks this command will give the player the control over its motion back
		if(quest_solved)
		{
			player.GetComponent<OVRGamepadController>().enabled = true;
		}	
	}
	
	void OnTriggerExit (Collider other)
	{	
		
		//zeroes the count for button 'B' out again
		gamepadB_press_count = 0;
		
		// Deletes GUI Message
		thisText.text = "";		
		
		// If the colliding gameobject is the player...
		if(other.gameObject == player)
		{
			doorAndKeypad_ACTIVE.SetActive(false);
			door_PASSIVE.SetActive(true);
		}
		if(other.gameObject == player && quest_solved && iteratorLock<1)
		{
			//i can not remember why it added this
			iteratorLock = iteratorLock + 1;
			
			//the 'active' Version of the Asset is now disabled
			doorAndKeypad_ACTIVE.SetActive(false);
			
			//the 'passive' Version of the Asset (static Mesh and Texture) only, is enabled
			door_PASSIVE.SetActive(true);
			
			//the 'passive' Door is rotated so that it looks like it has been opened and
			//still stays open, when the 'active' Door is deleted
			door_PASSIVE_collider.transform.Rotate(doorRotation,Space.Self);
						
		}
		
			
	}
	
	
	
	
}