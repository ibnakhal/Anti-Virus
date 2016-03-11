/************************
-------------------------
|*   wormAI(wAI).cs    *|
|*   Ibrahim Nakhal    *|
|*   Student           *|
|*   AAU Game Design   *|
-------------------------
************************/
using UnityEngine;
using System.Collections;

public class wAI : MonoBehaviour
{
    [SerializeField]
    private GameObject head = null;
    [SerializeField]
    private Vector3 vector = new Vector3(0, 0, 0);
    [SerializeField]
    private Transform direction = null;
    [SerializeField]
    public float force = 8f;
    [SerializeField]
    private int dmg;
    [SerializeField]
    public GameObject rear;
    [SerializeField]
    private EnemyHealthScript health;



    /// <summary>
    /// starts off the worm in a random direction
    /// </summary>
    public void Start()
    {
        vector = new Vector3(Random.Range(-360, 360), Random.Range(-360, 360), Random.Range(-360, 360));
        this.transform.LookAt(vector);
        this.transform.Translate(Vector3.forward * Time.deltaTime);
        this.GetComponent<Collider>().enabled = true;
        health = this.gameObject.GetComponent<EnemyHealthScript>();
    }


    public void Update()
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime * force);
        if(rear == null)
        {
            health.health = 0;
        }

    }
    /// <summary>
    /// on hitting a wall (Other) the worm will run in a different and completely random direction
    /// also on hitting a bullet will destroy itself
    /// </summary>
    /// <param name="Other"> placeholder to link tags to walls</param>
   /* public void OnTriggerEnter(Collider Other)
    {


    }*/

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("I HIT");
        Vector3 normal = collision.contacts[0].normal;

        Collider Other = collision.collider;

        if (Other.tag == "wall")
        {
            Debug.Log("WAll hit");
//           Vector3 kiddy = Other.transform.FindChild("DIRECT").forward;
            vector = Vector3.Reflect(this.transform.forward, normal);
            this.transform.LookAt(this.transform.position + vector);
            Move();
        }
        if (Other.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }

        if (Other.tag == "Player")
        {
            Other.GetComponent<PlayerController>().Ouch(dmg);
        }
    }


    public void Move()
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime * force);
    }



}



