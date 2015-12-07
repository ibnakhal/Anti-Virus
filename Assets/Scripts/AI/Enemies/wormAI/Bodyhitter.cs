using UnityEngine;
using System.Collections;

public class Bodyhitter : MonoBehaviour {







    [SerializeField]
    private int dmg;


    public void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Player")
        {
            Other.GetComponent<PlayerController>().Ouch(dmg);
        }
    }




}
