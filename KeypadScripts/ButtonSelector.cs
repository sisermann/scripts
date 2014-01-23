using UnityEngine;
using System.Collections;

public class ButtonSelector : MonoBehaviour 
{
	private GameObject [] buttons = new GameObject[0];
	private Vector3 newTrans;
	
	private bool movePositiveX = false;
	private bool moveNegativeX = false;
	
	private bool movePositiveY = false;
	private bool moveNegativeY = false;
	
	private bool movePositiveZ = false;
	private bool moveNegativeZ = false;

	public float jumpIncrement = 0;

	private float jumpValueX = 0;
	private float jumpValueY = 0;
	private float jumpValueZ = 0;

	public float deadZoneMAX = 0.9f;
	public float deadZoneMIN = 0.0f;
	
	// for the configuration of the Button Selectors Orientation in side the group
	
	public Orientation orientation;
	public enum Orientation {posX, negX, posZ, negZ}

	private float y;
	private float z;
	
	private int i = 0;
	private int step = 0;
	
	private float moveX = 0.0f;
	private float moveY = 0.0f;
	private float moveZ = 0.0f;
	
	void Awake()
	{
		jumpValueY = 0.07f;

		// sets the Orientation by the Orientation enum menu under the Button Selector Script
		if(orientation == Orientation.posX)
		{
			jumpValueX = jumpIncrement;
			jumpValueZ = 0;
		}

		moveX = transform.position.x;
		moveY = transform.position.y;
		moveZ = transform.position.z;


	}
	

	
	void MotionJumpBased()
	{
		//Setting the postion 
		transform.position = new Vector3(moveX, moveY, moveZ);
		
		// Added for the case that you have to move the Z-Axis
		
		//DEPTH TESTING //DEPTH TESTING //DEPTH TESTING //DEPTH TESTING //DEPTH TESTING
		//DEPTH TESTING //DEPTH TESTING //DEPTH TESTING //DEPTH TESTING //DEPTH TESTING
		//DEPTH TESTING //DEPTH TESTING //DEPTH TESTING //DEPTH TESTING //DEPTH TESTING
		//DEPTH TESTING //DEPTH TESTING //DEPTH TESTING //DEPTH TESTING //DEPTH TESTING
		
		// Tests if Horizontal Axis is in the Zone Z-Axis
		if(Input.GetAxisRaw("Horizontal") < deadZoneMAX && Input.GetAxisRaw("Horizontal") > deadZoneMIN)
		{
			movePositiveZ = true;
			moveNegativeZ = false;
		}
		// Tests if Horizontal Axis is in the Zone
		if(Input.GetAxisRaw("Horizontal") > -deadZoneMAX && Input.GetAxisRaw("Horizontal") < deadZoneMIN)
		{
			movePositiveZ = false;
			moveNegativeZ = true;
		}
		// Tests if Horizontal Axis is above the Zone, if that is so it sets the bool to false so that the test quits
	 	if(Input.GetAxisRaw("Horizontal") > deadZoneMAX && movePositiveZ)
		{
			moveZ = moveZ + jumpValueZ;

			movePositiveZ = false;
			moveNegativeZ = false;
		}
		// Tests if Horizontal Axis is above the Zone, if that is so it sets the bool to false so that the test quits
		if(Input.GetAxisRaw("Horizontal") < -deadZoneMAX && moveNegativeZ)
		{
			moveZ = moveZ - jumpValueZ;

			movePositiveZ = false;
			moveNegativeZ = false;
		}

		// Tests if Horizontal Axis is in the Zone X-Axis
		if(Input.GetAxisRaw("Horizontal") < deadZoneMAX && Input.GetAxisRaw("Horizontal") > deadZoneMIN)
		{
			movePositiveX = true;
			moveNegativeX = false;
		}
		// Tests if Horizontal Axis is in the Zone
		if(Input.GetAxisRaw("Horizontal") > -deadZoneMAX && Input.GetAxisRaw("Horizontal") < deadZoneMIN)
		{
			movePositiveX = false;
			moveNegativeX = true;
		}
		// Tests if Horizontal Axis is above the Zone, if that is so it sets the bool to false so that the test quits
		if(Input.GetAxisRaw("Horizontal") > deadZoneMAX && movePositiveX)
		{
			moveX = moveX + jumpValueX;
			
			movePositiveX = false;
			moveNegativeX = false;
		}
		// Tests if Horizontal Axis is above the Zone, if that is so it sets the bool to false so that the test quits
		if(Input.GetAxisRaw("Horizontal") < -deadZoneMAX && moveNegativeX)
		{
			moveX = moveX - jumpValueX;
			
			movePositiveX = false;
			moveNegativeX = false;
		}
		
		// VERTICAL TESTING // VERTICAL TESTING // VERTICAL TESTING // VERTICAL TESTING // VERTICAL TESTING
		// VERTICAL TESTING // VERTICAL TESTING // VERTICAL TESTING // VERTICAL TESTING // VERTICAL TESTING
		// VERTICAL TESTING // VERTICAL TESTING // VERTICAL TESTING // VERTICAL TESTING // VERTICAL TESTING
		// VERTICAL TESTING // VERTICAL TESTING // VERTICAL TESTING // VERTICAL TESTING // VERTICAL TESTING
		if(Input.GetAxisRaw("Vertical") < deadZoneMAX && Input.GetAxisRaw("Vertical") > deadZoneMIN)
		{
			movePositiveY = true;
			moveNegativeY = false;
		}
		// Tests if Vertical Axis is in the Zone
		if(Input.GetAxisRaw("Vertical") > -deadZoneMAX && Input.GetAxisRaw("Vertical") < deadZoneMIN)
		{
			movePositiveY = false;
			moveNegativeY = true;
		}
		// Tests if Vertical Axis is above the Zone, if that is so it sets the bool to false so that the test quits
	 	if(Input.GetAxisRaw("Vertical") > deadZoneMAX && movePositiveY)
		{
			moveY = moveY + jumpValueY;
						
			movePositiveY = false;
			moveNegativeY = false;
		}
		// Tests if Vertical Axis is above the Zone, if that is so it sets the bool to false so that the test quits
		if(Input.GetAxisRaw("Vertical") < -deadZoneMAX && moveNegativeY)
		{
			moveY = moveY - jumpValueY;
			
			movePositiveY = false;
			moveNegativeY = false;
		}
		
				
	}
	
	void Update() 
	{	
		//MotionArrayBased();
		MotionJumpBased();
    }

	
		
}
