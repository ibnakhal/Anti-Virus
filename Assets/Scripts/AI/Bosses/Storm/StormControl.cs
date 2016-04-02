using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StormControl : MonoBehaviour {


    [SerializeField]
    public List<GameObject> Parts = new List<GameObject>();
    [SerializeField]
    public GameObject parent;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Parts == null || Parts.Count == 0)
        {
            Debug.Log("I'm empty");
            parent.GetComponent<RoomController>().contents.Remove(gameObject);

            Destroy(this.gameObject);
        }

    }
}

