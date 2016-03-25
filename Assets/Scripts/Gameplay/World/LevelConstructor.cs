using UnityEngine;
using System.Collections;

public class LevelConstructor : MonoBehaviour {

    [SerializeField]
    private GameObject[] LevelSection;
    [SerializeField]
    private GameObject[] LevelPoints;
    [SerializeField]
    private int levelMinimum;




	// Use this for initialization
	void Start () {
        LevelPoints = GameObject.FindGameObjectsWithTag("LevelPoint");
        int rando = Random.Range(levelMinimum, LevelPoints.Length);
        for(int x=0; x<rando; x++)
        {
            int y = Random.Range(0, LevelSection.Length);
            Instantiate(LevelSection[y], LevelPoints[x].transform.position, Quaternion.identity);
        }
        RandomSpawn spawn = this.gameObject.GetComponent<RandomSpawn>();
        spawn.Plort();
        TeleportControl tele = this.gameObject.GetComponent<TeleportControl>();
        tele.KickStarter();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
