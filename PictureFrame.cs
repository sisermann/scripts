using UnityEngine;
using System.Collections;

public class PictureFrame : MonoBehaviour {
	
	string localTex = null;
	private Texture2D PictureTexture = null;
	
	public void useTex(string inputTex)
	{
		
		
		localTex = "file://" +inputTex;
		localTex = localTex.Replace('\\', '/');
		
		WWW URL = new WWW(localTex);
		
		PictureTexture = URL.texture;
		
		renderer.material.mainTexture = PictureTexture;
		
		//Debug.Log (localTex);
			
	}
	
}
