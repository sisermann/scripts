using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour 
{
	public float openDelay = 1.0f;
	public bool doorIsOpen = false;
	
	public void OpenTheDoor()
	{
		if(!doorIsOpen)
		{
			StartCoroutine(PlayAnim());
			doorIsOpen = true;
		}
	}
	
	IEnumerator PlayAnim()
	{	
		yield return new WaitForSeconds(openDelay);
		animation.Play();
	}
}
