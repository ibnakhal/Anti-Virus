/************************
-------------------------
|*   Twister.cs        *|
|*   Ibrahim Nakhal    *|
|*   Student           *|
|*   AAU Game Design   *|
-------------------------
************************/
using UnityEngine;
using System.Collections;




public class Twister : MonoBehaviour {

	public float speed = 10f;


	void Update () {
		this.transform.Rotate (Vector3.forward, Time.deltaTime * speed);
	}
}
