using UnityEngine;
using System.Collections;

public class HiveBehavior : MonoBehaviour {
    [SerializeField]
    private int destinationThreshold;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform[] holes;
    [SerializeField]
    private float spawnIntervals;
    [SerializeField]
    private float turnspeed;
    [SerializeField]
    private bool inside;
    [SerializeField]
    private int x;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (inside)
        {
            //this is the wrong way to do it, need a transform.translate in deltaTime but limit it in another way.
            while (x < destinationThreshold)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
                x++;
            }

        }
    }

    public void OnTriggerEnter(Collider Other)
    {
        if(Other.tag == "Player")
        {
            inside = true;
            x = 0;
            Activate();
        }
    }

    public void Activate()
    {
       
    }

}
