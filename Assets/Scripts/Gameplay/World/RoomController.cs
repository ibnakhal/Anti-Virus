using UnityEngine;
using System.Collections;

public class RoomController : MonoBehaviour {


    [SerializeField]
    private GameObject[] contents;
    [SerializeField]
    private GameObject reward;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if (contents == null)
        {
            reward.SetActive(true);
        }



	}




    public void OnTriggerEnter(Collider Other)
    {
        if(Other.tag == "Player")
        {
            for (int x = 0; x< contents.Length; x++)
            {
                contents[x].SetActive(true);
            }
        }
    }
}
