using UnityEngine;
using System.Collections;

public class BallMotion : MonoBehaviour 
{
	//public Transform target;
    //private Vector3 _direction;
	
	private float _distance;
	public float acceleration = 100000f;
	
	private int _torqueFront = 200;
	private int _torqueUp;
		
	void Update()
	{	
		
		//_direction = (target.position - transform.position).normalized;
		//_distance = Vector3.Distance(transform.position,target.position);
			
	}
	
	void FixedUpdate()
	{	
		
		//rigidbody.AddForce(_direction*_acceleration*_distance);
		//rigidbody.AddTorque(_torqueFront*_acceleration,0,0);
		float moveHorizontal = Input.GetAxis("Vertical");
		float moveVertical = Input.GetAxis("Horizontal");
		float moveZ = Input.GetAxis("Mouse ScrollWheel")*100;
		
		Vector3 movement = new Vector3( moveHorizontal , 0, moveVertical*-1);
		
		Debug.Log (moveZ);
		
		rigidbody.AddTorque(movement*acceleration*Time.deltaTime);
			
	}
	
}



	
