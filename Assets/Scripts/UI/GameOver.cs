using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    [SerializeField]
    private int mainmenu;
    [SerializeField]
    private Stats gStart;

	// Use this for initialization
	void Start () {
        StartCoroutine(CountDown());
        gStart = GameObject.FindGameObjectWithTag("Background").GetComponent<Stats>();
	}
	

        public IEnumerator CountDown()
    {
        yield return new WaitForSeconds(5);
        gStart.maxHp = 100;
        gStart.hP = 100;

        for (int z = 0; z < gStart.ammo.Length; z++)
        {
            gStart.ammo[z] = 0;
        }
            Application.LoadLevel(mainmenu);
    }
}
