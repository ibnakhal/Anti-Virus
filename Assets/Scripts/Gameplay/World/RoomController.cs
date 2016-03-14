using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomController : MonoBehaviour {


    [SerializeField]
    public List<GameObject> contents = new List<GameObject>();
    [SerializeField]
    private GameObject[] reward;
    [SerializeField]
    private Transform spawn;
    [SerializeField]
    private GameObject[] doors;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if (contents == null || contents.Count == 0)
        {
            Debug.Log("Done");
            for (int x = 0; x < doors.Length; x++)
            {
                doors[x].SetActive(true);
                doors[x].GetComponent<TeleporterRoom>().cleared = true;
            }
            int rando = Random.Range(0, reward.Length);
            Instantiate(reward[rando], spawn.position, spawn.rotation);
        }



	}




    public void OnTriggerEnter(Collider Other)
    {
        if(Other.tag == "Player")
        {
            for (int x = 0; x< contents.Count; x++)
            {
                contents[x].SetActive(true);
            }
            for(int x = 0; x< doors.Length; x++)
            {
                doors[x].SetActive(false);
            }
        }
    }
}
