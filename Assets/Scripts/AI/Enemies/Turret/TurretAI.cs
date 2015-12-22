using UnityEngine;
using System.Collections;

public class TurretAI : MonoBehaviour {


    [SerializeField]
    private Transform[] shotLocations;
    [SerializeField]
    private float volleyTime;
    [SerializeField]
    private int volleyCount;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float speed;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Fire());
	}
	
	// Update is called once per frame
	void Update () {

        this.gameObject.transform.Rotate(Vector3.up * Time.deltaTime * speed);


	}

    public IEnumerator Fire()
    {


        while (isActiveAndEnabled)
        {
            yield return new WaitForSeconds(volleyTime);

            for(int x = 0; x< volleyCount;)
            {
                yield return new WaitForSeconds(0.1f);
                int r = Random.Range(0, shotLocations.Length);
                Vector3 VectorD = (player.transform.position - shotLocations[r].position);
                Ray cast = new Ray(shotLocations[r].position, VectorD);
                RaycastHit hit;
                bool infoReturn = Physics.Raycast(cast, out hit, 100);
                if (infoReturn)
                {
                    if(hit.transform.gameObject == this.gameObject)
                    {
                        Debug.Log("Missed the player");
                        r = Random.Range(0, shotLocations.Length);
                    }
                    else if (hit.transform.gameObject == player)
                    {
                        GameObject clone = Instantiate(bullet, shotLocations[r].position, shotLocations[r].rotation) as GameObject;
                        clone.GetComponent<Rigidbody>().velocity = (VectorD * Time.deltaTime * 50);
                        x++;

                    }

                }
            }



        }



    }




}
