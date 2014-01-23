using UnityEngine;
using System.Collections;

public class Listener_ButtonI : MonoBehaviour 
{
	private KeypadControlScript keypad;
	
	Color flashColor = Color.grey;
	
	void Awake ()
	{
		keypad = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<KeypadControlScript>();
		
	}
	
	IEnumerator FlashColor()
	{	
		renderer.material.color = flashColor;
		renderer.material.SetColor("_GlowColor", flashColor);
		yield return new WaitForSeconds(0.1f);
		renderer.material.color = keypad.Buttons_pressed_color[8];
		renderer.material.SetColor("_GlowColor", keypad.Buttons_pressed_color[8]);
		
	}
	
	/*void OnMouseDown()
	{
		keypad.ButtonAccess(8,1);
		StartCoroutine(FlashColor());
	}*/
	
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == Tags.selector && Input.GetButtonDown("Fire1"))
		{
			keypad.ButtonAccess(8,1);
			StartCoroutine(FlashColor());
		}
	}
}
