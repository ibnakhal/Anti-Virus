using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SegmentControl : MonoBehaviour {
    [SerializeField]
    public List<GameObject> Parts = new List<GameObject>();
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Parts == null || Parts.Count == 0)
        {
            Debug.Log("I'm empty");
            gameObject.GetComponentInParent<RoomController>().contents.Remove(gameObject);

            Destroy(this.gameObject);
        }
	
	}
}
