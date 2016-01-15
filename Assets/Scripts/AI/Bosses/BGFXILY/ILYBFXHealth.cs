using UnityEngine;
using System.Collections;

public class ILYBFXHealth : MonoBehaviour {

    [SerializeField]
    public int health;
    [SerializeField]
    private bool alive;
    [SerializeField]
    private GameObject masterParent;
    [SerializeField]
    private BFXMasterHealth masterHealth;
	// Use this for initialization
	void Start () {

        masterHealth = masterParent.GetComponent<BFXMasterHealth>();
	}
	
	// Update is called once per frame
	void Update () {


        if (health <= 0 && alive)
        {
            alive = false;
            masterHealth.HealthCheck();
        }
	
	}
}
