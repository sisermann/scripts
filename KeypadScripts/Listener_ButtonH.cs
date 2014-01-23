﻿using UnityEngine;
using System.Collections;

public class Listener_ButtonH : MonoBehaviour 
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
		renderer.material.color = keypad.Buttons_pressed_color[7];
		renderer.material.SetColor("_GlowColor", keypad.Buttons_pressed_color[7]);
		
	}
	
	/*void OnMouseDown()
	{
		keypad.ButtonAccess(7,1);
		StartCoroutine(FlashColor());
	}*/
	
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == Tags.selector && Input.GetButtonDown("Fire1"))
		{
			keypad.ButtonAccess(7,1);
			StartCoroutine(FlashColor());
		}
	}
}
