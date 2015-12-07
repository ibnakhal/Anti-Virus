using UnityEngine;
using System.Collections;

public class CodeRedBasicBehavior : MonoBehaviour {


    [Header("Health Variables")]
    [SerializeField]
    private int hp;
    [SerializeField]
    private int maxHp;
    [SerializeField]
    private float hpPercent;



    [Header ("Stage Change Variables")]
    [SerializeField]
    private float speed;
    [SerializeField]
    private float lerpValue;
    [SerializeField]
    private float timer;
    [SerializeField]
    private float duration;
    [SerializeField]
    private Vector3 vStart, vEnd;
  
    [Header ("Stage 2 Pieces")]
    [SerializeField]
    private GameObject s2;
    [SerializeField]
    private float range;
    [SerializeField]
    private Transform[] points;
    [SerializeField]
    private Transform[] s2Points;
    [SerializeField]
    private bool stage2 = false;
    [SerializeField]
    private bool Laser = false;


	// Use this for initialization
	void Start () {

        
	
	}
	
	// Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up * Time.deltaTime * speed);
        s2.transform.localScale = Vector3.Lerp(vStart, vEnd, lerpValue);

        hpPercent = (((float)hp / (float)maxHp) * 100);

        if (hpPercent < 50)
        {
            stage2 = true;
        }
        if (stage2)
        {
            
            timer += Time.deltaTime;

            lerpValue = (timer / duration);
        }
    }

    public void Fire()
    {
        while (Laser)
        {
            int r = Random.Range(0,points.Length);
            Ray cast = new Ray(points[r].position, points[r].forward);
            RaycastHit hit;
            bool retreive = Physics.Raycast(cast, out hit, range);
            Debug.Log(retreive);
        }
    }


    public void GetHurt(int damage)
    {
        hp -= damage;
    }
}
