using UnityEngine;
using System.Collections;

public class Failsafe : MonoBehaviour {
    [SerializeField]
    private Transform Origin;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


public void     OnTriggerExit(Collider Other)
    {
        if(Other.tag == "Player")
        {
            Other.transform.position = Origin.position;
        }
        if(Other.tag == "Boss")
        {
            Other.SendMessage("Targeting");
        }



    }

}
