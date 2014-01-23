using UnityEngine;
using System.Collections;

public class KeypadControlScript : MonoBehaviour 
{
	internal int [] Buttons_quest = {1,1,2,1,2,1,1,2,3};
	internal int [] Buttons_pressed = {0,0,0,0,0,0,0,0,0};
	internal bool [] Buttons_quest_LOCKED = {false,false,false,false,false,false,false,false,false};
	
	public bool All_Buttons_quest_LOCKED = false;
	
	public AudioSource buttonTone;
	
	internal OpenDoor theDoor;
	
	private Color [] ColorsA = {Color.black,Color.cyan,Color.green,Color.red,Color.yellow,Color.magenta,Color.blue,Color.black};
	//private Color [] ColorsA = {Color.black,Color.cyan,Color.magenta};
	
	internal Color [] Buttons_pressed_color = new Color[9];
	
	internal Color [] Buttons_quest_color = new Color[9];
	
	void Awake()
	{
		theDoor = GameObject.FindGameObjectWithTag(Tags.door).GetComponent<OpenDoor>();
		SetQuestValues();
		SetQuestColors();
	}
	
	void SetQuestValues()
	{
		for(int i=0; i<Buttons_quest.Length; i++)
		{
			Buttons_quest[i] = Random.Range(1,ColorsA.Length);
		}
	}
	
	void SetQuestColors()
	{
		for(int i=0; i<Buttons_quest.Length; i++)
		{
			Buttons_quest_color[i] = ColorsA[Buttons_quest[i]];
		}
	}
	
	void CheckButtonsLocked()
	{
		if(Buttons_quest_LOCKED[0] && Buttons_quest_LOCKED[1] && Buttons_quest_LOCKED[2]
			&& Buttons_quest_LOCKED[3] && Buttons_quest_LOCKED[4] && Buttons_quest_LOCKED[5] && 
			Buttons_quest_LOCKED[6] && Buttons_quest_LOCKED[7] && Buttons_quest_LOCKED[8])
		{
			theDoor.OpenTheDoor();
			All_Buttons_quest_LOCKED = true;
		
		}
	}
	
	public void ButtonAccess(int index, int a)
	{
		CheckButtonsLocked();
		
		Buttons_pressed[index] = Buttons_pressed[index] + a;
		
		if(a == 1)
		{
			buttonTone.Play();
			
			if(Buttons_pressed[index] >= ColorsA.Length)
			{
				Buttons_pressed[index] = 1;
			}
			if(Buttons_pressed[index] == Buttons_quest[index])
			{
				Buttons_quest_LOCKED[index] = true;
				
				buttonTone.pitch = 1*0.75f;
				buttonTone.volume = 1.0f;
				CheckButtonsLocked();
			}
			else
			{
				Buttons_quest_LOCKED[index] = false;
				
				buttonTone.pitch = 1.0f;
				buttonTone.volume = 1.0f;
				CheckButtonsLocked();
			}
		}
		Buttons_pressed_color[index] = ColorsA[Buttons_pressed[index]];
	}
	
}

