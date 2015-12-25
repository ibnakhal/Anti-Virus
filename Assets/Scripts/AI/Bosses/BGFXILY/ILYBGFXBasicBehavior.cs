using UnityEngine;
using System.Collections;

public class ILYBGFXBasicBehavior : MonoBehaviour {
    [SerializeField]
    private Vector3 turnDirection;
    [SerializeField]
    private float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.Rotate(turnDirection * Time.deltaTime * speed);

	}
}
