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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void OnTriggerEnter(Collider Other)
    {
        if(Other.tag == "Player")
        {
            Activate();
        }
    }

    public void Activate()
    {
        if (inside)
        {
            for (int x = 0; x < destinationThreshold; x++)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }

        }
    }

}
