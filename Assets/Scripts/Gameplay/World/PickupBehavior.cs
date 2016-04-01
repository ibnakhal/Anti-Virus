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
        adware,

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
                    break;
               
                
                case Type.trojanHp:
                    pC.HealUp(modifier);
                    pC.Troj();
                    break;
                case Type.malware:
                    Debug.Log("Boombooom");
                    pC.Mal();
                    break;
                case Type.adware:
                    pC.Ad();
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
