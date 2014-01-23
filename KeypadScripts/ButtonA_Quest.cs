using UnityEngine;
using System.Collections;

public class ButtonA_Quest : MonoBehaviour 
{
	private KeypadControlScript keypad;
	private Color ColorLerpTest = Color.white;
	
	public GameObject [] questButtons;
	
	void Awake()
	{
		keypad = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<KeypadControlScript>();
		
	}
	
	void Update()
	{
		SetValue();
	}
	
	void SetValue()
	{
		//ColorLerpTest = Color.Lerp(ColorLerpTest , keypad.Buttons_quest_color[0], 0.05f);
		//renderer.material.color = ColorLerpTest;
		int i = 0;
		
		foreach(GameObject questButton in questButtons)
		{
			questButton.renderer.material.color = keypad.Buttons_quest_color[i];
			i++;
		}
		
	}
	
	
}
	


