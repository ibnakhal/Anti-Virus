using UnityEngine;
using System.Collections;

public class RandomSpawn : MonoBehaviour {
    [SerializeField]
    private GameObject[] bossRooms;
    [SerializeField]
    private Transform spawn;

	// Use this for initialization
	public void Plort () {
        int rando = Random.Range(0, bossRooms.Length);
        Instantiate(bossRooms[rando], spawn.position, spawn.rotation);
	
	}
	
}
