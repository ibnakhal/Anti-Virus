using UnityEngine;
using System.Collections;

public class CryoInfection : MonoBehaviour {




    [SerializeField]
    private GameObject Plumage;
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
            Other.GetComponent<PlayerController>().cryoHit++;


            Instantiate(Plumage, this.transform.position, this.transform.rotation);
            Destroy(this.transform.parent.gameObject);

        }
    }
}
