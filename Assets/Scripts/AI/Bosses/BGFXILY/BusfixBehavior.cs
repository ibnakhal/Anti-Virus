using UnityEngine;
using System.Collections;

public class BusfixBehavior : MonoBehaviour
{

    [SerializeField]
    private GameObject[] sLocations;
    [SerializeField]
    private int volleys;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float bulletForce;
    [SerializeField]
    private int stage;
    [SerializeField]
    private bool Done;
    public enum StateType
    {
        Fire,
        Shield,
        size,

    }
    // Use this for initialization
    void Start () {
        StartCoroutine(Fire());
	}
	
	// Update is called once per frame
	void Update () {
	
	}




    public void Startup()
    {

    }

    public IEnumerator Started()
    {
        while (isActiveAndEnabled)
        {
            yield return new WaitForSeconds(1);
            if (Done)
            {
                int s = Random.Range(0, ((int)StateType.size - stage));
                StateType state = (StateType)s;
                string name = state.ToString();
                print(name);
                StartCoroutine(name);
            }

        }

    }


    public IEnumerator Upkeep()
    {
        while(isActiveAndEnabled)
        {
            yield return new WaitForSeconds(3);
            sLocations = GameObject.FindGameObjectsWithTag("Boss");
        }
    }


    public IEnumerator Fire()
    {
        for(int x= 0; x< volleys; x++)
        {
            for(int y = 0; y<sLocations.Length; y++)
            {
                GameObject clone = Instantiate(bullet, sLocations[y].transform.position, this.transform.rotation) as GameObject;
                clone.GetComponent<PayloadMovement>().vector = sLocations[y].transform.forward;

            }

            yield return new WaitForSeconds(2);
        }



    }

}
