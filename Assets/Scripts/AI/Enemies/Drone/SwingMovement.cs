using UnityEngine;
using System.Collections;

public class SwingMovement : MonoBehaviour {
    [SerializeField]
    private Vector3 left;
    [SerializeField]
    private float degreeModifier;
    [SerializeField]
    private float someConstant;
    [SerializeField]
    private Transform player;


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        float degree = degreeModifier * (Mathf.Sin(Time.timeSinceLevelLoad * someConstant));
       // degree = 0;

        Quaternion forwardRotation;
        
        forwardRotation = Quaternion.LookRotation(player.position);

        transform.rotation = forwardRotation * Quaternion.Euler(0.0f, degree, 0.0f);
        

        }
}
