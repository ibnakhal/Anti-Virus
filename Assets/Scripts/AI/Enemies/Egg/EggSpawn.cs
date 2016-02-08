using UnityEngine;
using System.Collections;

public class EggSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject Egg;
    [SerializeField]
    private Transform spawnLocation;
    [SerializeField]
    private float minspawn;
    [SerializeField]
    private float maxpawn;
    [SerializeField]
    private float minspawnForce;
    [SerializeField]
    private float maxspawnForce;
    public void Start()
    {
        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        while (isActiveAndEnabled)
        {
            float spoof = Random.Range(minspawn, maxpawn);
            yield return new WaitForSeconds(spoof);
            GameObject clone = Instantiate(Egg, spawnLocation.position, spawnLocation.rotation) as GameObject;
            float spiff = Random.Range(minspawnForce, maxspawnForce);
            clone.GetComponent<Rigidbody>().AddForce(new Vector3(0,1,1) * spiff);

        }


    }
}
