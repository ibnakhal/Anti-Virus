using UnityEngine;
using System.Collections;

public class AWormMovement : MonoBehaviour {
    [SerializeField]
    private Vector3 vector;
    [SerializeField]
    private float tSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(vector * Time.deltaTime * tSpeed);
	}
}
