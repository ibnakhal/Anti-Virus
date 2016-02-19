using UnityEngine;
using System.Collections;

public class OnEnter : MonoBehaviour {

    [SerializeField]
    private int damage;

    public void OnCollisionEnter(Collision collided)
    {
        Debug.Log(collided.collider.name);
        Collider Other = collided.collider;
        if (Other.tag == "Player")
        {
            Other.GetComponent<PlayerController>().Ouch(damage);
        }
    }
    public void OnTriggerEnter (Collider Other)
    {

        if (Other.tag == "Player")
        {
            Other.GetComponent<PlayerController>().Ouch(damage);
        }
    }

  
}
