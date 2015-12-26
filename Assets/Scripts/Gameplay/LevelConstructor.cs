using UnityEngine;
using System.Collections;

public class LevelConstructor : MonoBehaviour {

    [SerializeField]
    private GameObject[] LevelSection;
    [SerializeField]
    private GameObject[] LevelPoints;




	// Use this for initialization
	void Start () {
        LevelPoints = GameObject.FindGameObjectsWithTag("LevelPoint");
	
        for(int x=0; x<LevelPoints.Length; x++)
        {
            int y = Random.Range(0, LevelSection.Length);
            Instantiate(LevelSection[y], LevelPoints[x].transform.position, Quaternion.identity);
        }


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
