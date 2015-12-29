using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    [SerializeField]
    private float radius;
    [SerializeField]
    private int damage;



	// Use this for initialization
	void Start () 
    {
        Collider[] hits = Physics.OverlapSphere(this.transform.position, radius);
        foreach (Collider hit in hits)
        {
            if (hit.transform.tag == "Player")
            {
                print("Locked");
                PlayerController playerC = hit.GetComponent<PlayerController>();

                playerC.Ouch(damage);
            }
        }
	


	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
