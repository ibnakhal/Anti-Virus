using UnityEngine;
using System.Collections;

public class Egg : MonoBehaviour {
    [SerializeField]
    private GameObject[] spawnRange;
    [SerializeField]
    private GameObject sparkle;

    public void OnTriggerEnter()
    {
        int rando = Random.Range(0, spawnRange.Length);
        Instantiate(sparkle, this.transform.position, this.transform.rotation);
        Instantiate(spawnRange[rando], this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);

    }

}
