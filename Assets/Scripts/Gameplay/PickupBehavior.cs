/************************
-------------------------
|*   PickupBehavior.cs *|
|*   Ibrahim Nakhal    *|
|*   Student           *|
|*   AAU Game Design   *|
-------------------------
************************/

using UnityEngine;
using System.Collections;

public class PickupBehavior : MonoBehaviour 
{
    [SerializeField]
    private float speed = 100;
    [SerializeField]
    private PlayerController pC;
    enum Type
    {
        hp,
        max,
        trojanHp,
        malware,
    }
    [SerializeField]
    private Type typheus;
    [SerializeField]
    private int modifier;



    public void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        pC = p.GetComponent<PlayerController>();
    }


    public void OnTriggerEnter (Collider Other)
    {
        if (Other.tag == "Player")
        {
            switch(typheus)
            {
                case Type.hp:
                    pC.HealUp(modifier);
                    break;

                case Type.max:
                    pC.MaxUp(modifier);
                   // pC.HealUp(modifier);
                    break;
               
                
                case Type.trojanHp:
                    pC.HealUp(modifier);
                    pC.trojand = true;
                    break;
                case Type.malware:
                    pC.Maled = true;
                    StartCoroutine(pC.Mal(modifier));
                    break;

            }
            Destroy(this.gameObject);
        }
    }
    public void Update()
    {
        this.transform.Rotate(Vector3.up * Time.deltaTime * speed);
    }

}
