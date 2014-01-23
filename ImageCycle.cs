using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

public class ImageCycle : MonoBehaviour {
	
	public Texture2D LogoTexture = null;
	public Rect LogoTextureDimensions;
	public GameObject[] PictureFrameArray;
	public int numPics = 0;
	
	// Use this for initialization
	void Start () 
	{	
		
		var set = new HashSet<string> { ".jpg", ".png" };
		string[] Files = Directory.GetFiles(Path.GetFullPath("."), "*.*", SearchOption.TopDirectoryOnly)
         .Where(f => set.Contains(
             new FileInfo(f).Extension,
             StringComparer.OrdinalIgnoreCase)).ToArray();
		
		PictureFrameArray = GameObject.FindGameObjectsWithTag("PictureFrame");
		
		foreach (GameObject test in PictureFrameArray)
		{	
			if(numPics < Files.Length)
			{
				PictureFrame insertText = test.GetComponentInChildren<PictureFrame>();
				insertText.useTex(Files[numPics++]);
			}
			else
			{
				numPics = numPics - Files.Length;	
			}
		}
		
	}
	
	// Update is called once per frame
		
	void Update () {
	
	}
	
	void OnGUI()
	{
		
	}
	
	/*IEnumerator ShowImages()
	{
		//Get image files
		var set = new HashSet<string> { ".jpg", ".png" };
		string[] Files = Directory.GetFiles(Path.GetFullPath("."), "*.*", SearchOption.TopDirectoryOnly)
         .Where(f => set.Contains(
             new FileInfo(f).Extension,
             StringComparer.OrdinalIgnoreCase)).ToArray();
		
		foreach(string FileName in Files)
		{
			//Create complete path
			string FullPath = "file://" + FileName;
			FullPath = FullPath.Replace('\\', '/');
			
			WWW URL = new WWW(FullPath);
			
			//Wait for load
			yield return URL;
			
			//Load texture
			LogoTexture = URL.texture;
			
			Debug.Log (FullPath);
			
			
			
			//Show logo duration
			yield return new WaitForSeconds(2);
		}
		
		StartCoroutine(ShowImages());
	}*/
}
