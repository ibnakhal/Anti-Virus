/************************
-------------------------
|*   AFKCloseApp.cs    *|
|*   Michael Witzel    *|
|*   Work Scholar      *|
|*   AAU Game Design   *|
|*   Kiosk Game Loader *|
-------------------------
************************/

using UnityEngine;
using System.Collections;

public class AFKCloseApp : MonoBehaviour 
{
	private float waitMinutes = 1.25f; //minutes

	private void Awake() 
	{
		DontDestroyOnLoad(this.transform.gameObject);
	}
	
	// Use this for initialization
	private void Start () 
	{
		waitMinutes *= 60;
		
		StartCoroutine ("AFKTimer");
	}
	
	private void Update() 
	{
		if (Input.anyKeyDown)
		{
			StopCoroutine("AFKTimer");
			StartCoroutine ("AFKTimer");
		}
	}
	
	private IEnumerator AFKTimer()
	{
		yield return new WaitForSeconds (waitMinutes);
		CloseApp ();
	}
	
	private void CloseApp()
	{
		Application.Quit();
	}
}