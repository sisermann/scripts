using UnityEngine;
using System.Collections;

public class changeTex : MonoBehaviour {
	
	public Texture newTex;
	
	// Use this for initialization
	void Start () {
		ChangeTex(newTex);
	}
	
	void ChangeTex(Texture theTex){
		
		renderer.material.mainTexture = theTex; 
	}
		
}
