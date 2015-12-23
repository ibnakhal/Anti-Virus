using UnityEngine;
using System.Collections;

public class SensorKamikazee : MonoBehaviour
{

    [SerializeField]
    private GameObject parent;

public void OnTriggerEnter(Collider Other)
    {
        if(Other.tag == "Player")
        {
            parent.GetComponent<PayloadMovement>().Kamikazee();



        }
    }



}

