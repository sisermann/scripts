using UnityEngine;
using System.Collections;

public class testTrigger : MonoBehaviour 
{
	public bool Entered = false;
	
	void OnTriggerEnter ()
	{
		Entered = true;
	}
}
