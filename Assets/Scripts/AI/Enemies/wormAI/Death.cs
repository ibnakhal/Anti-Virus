/************************
-------------------------
|*   wormAI - Death.cs *|
|*   Ibrahim Nakhal    *|
|*   Student           *|
|*   AAU Game Design   *|
-------------------------
************************/
using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

	[SerializeField]
	private float countDown;




	// Use this for initialization
	void Start () {
        StartCoroutine("Die");
	}


	public IEnumerator Die ()
	{

	    
		yield return new WaitForSeconds (countDown);
	
		Destroy (this.gameObject);


	}



}
