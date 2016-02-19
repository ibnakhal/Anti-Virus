using UnityEngine;
using System.Collections;

public class StormAI : MonoBehaviour {
    [SerializeField]
    private GameObject head;
    [SerializeField]
    private Vector3  vector;
    [SerializeField]
    private Transform direction;
    [SerializeField]
    public float force = 15;
    [SerializeField]
    private int dmg;
    [SerializeField]
    private int counter;
    [SerializeField]
    private int threshold = 3;
    [SerializeField]
    private Transform player;

	// Use this for initialization
	public void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        vector = new Vector3(Random.Range(-360, 360), Random.Range(-360, 360), Random.Range(-360, 360));
        this.transform.LookAt(vector);
        this.transform.Translate(Vector3.forward * Time.deltaTime);
        this.GetComponent<Collider>().enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector3.forward * Time.deltaTime * force);

    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("I HIT");
        Vector3 normal = collision.contacts[0].normal;

        Collider Other = collision.collider;

        if (Other.tag == "wall")
        {
            Debug.Log("WAll hit");
            //           Vector3 kiddy = Other.transform.FindChild("DIRECT").forward;
            counter++;
            if (counter >= threshold)
            {
                vector = Vector3.Reflect(this.transform.forward, normal);
                this.transform.LookAt(this.transform.position + vector);
                Move();
                counter = 0;
            }
            else
            {
                vector = player.position;
                this.transform.LookAt(vector+ new Vector3(0,2,0));
                Move();
            }
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
