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
        GameObject clone = Instantiate(spawnRange[rando], this.transform.position, this.transform.rotation) as GameObject;
        GetComponentInParent<RoomController>().contents.Add(clone);
        GetComponentInParent<RoomController>().contents.Remove(this.gameObject);
        clone.transform.SetParent(this.transform.parent);
        Destroy(this.gameObject);

    }

}
