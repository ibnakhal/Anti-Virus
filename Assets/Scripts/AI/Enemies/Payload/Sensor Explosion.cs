using UnityEngine;
using System.Collections;

public class SensorExplosion : MonoBehaviour {


    [SerializeField]
    private GameObject explosion;



    public void OnTriggerEnter (Collider Other)
    {

        if (Other.tag == "Player")
        {
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);

        }
    }
}
