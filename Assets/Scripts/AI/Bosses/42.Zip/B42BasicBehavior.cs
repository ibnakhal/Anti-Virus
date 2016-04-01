using UnityEngine;
using System.Collections;

public class B42BasicBehavior : MonoBehaviour {

    [Header ("Basic Stats")]
    [SerializeField]
    private int CountdownTime;
    [SerializeField]
    private int health;

    [Header ("Stage Changing")]
    [SerializeField]
    private bool finalStage;
    [SerializeField]
    private float radius;
    [SerializeField]
    private float radialLimit;
    [SerializeField]
    private GameObject nextStage;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private bool stageChange;
    [SerializeField]
    private GameObject egg;
    [SerializeField]
    private Transform[] spawnSpots;
    
    [Header ("Color Pulsing")]
    public float lerpValue;
    [SerializeField]
    public float timer;
    [SerializeField]
    public float duration;
    [SerializeField]
    private Color startColor;
    [SerializeField]
    private Color endColor;
    [SerializeField]
    private Renderer rend;
    [SerializeField]
    private bool charging;
    [SerializeField]
    private bool pulsing;
    [SerializeField]
    private Transform trigger;


    [SerializeField]
    private GameObject destructible;


    public void GetHurt(int damage)
    {
        health -= damage;
    }
    // Use this for initialization
    void Start () {

        StartCoroutine(Countdown());
        player = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {

        if (charging)
        {

            timer += Time.deltaTime;

            lerpValue = (timer / duration);
            rend.material.color = Color.Lerp(startColor, endColor, lerpValue);

        }
        if (pulsing)
        {
            timer += Time.deltaTime;

            lerpValue = (timer / duration);
            rend.material.color = Color.Lerp(endColor, startColor, lerpValue);
        }
        else if (!charging && !pulsing)
        {
            lerpValue = 0;
        }

        if(health <= 0)// && !stageChange)
        {
            Destroy(destructible.gameObject);
        }
    }





    public IEnumerator Countdown()
    {
        for(int x = 0; x<CountdownTime+1; x++)
        {

            charging = true;
            yield return new WaitForSeconds(duration);
            charging = false;
            //            lerpValue = 0;
            timer = 0;


            pulsing = true;
            yield return new WaitForSeconds(duration);
            pulsing = false;
            //            lerpValue = 0;

            timer = 0;
    
            Debug.Log(CountdownTime - x);
        }



            stageChange = true;
            StartCoroutine(StageChange());

        Debug.Log("TIME!");
    }

    public IEnumerator StageChange()
    {
        
        while(stageChange)
        {
           
            charging = true;
            yield return new WaitForSeconds(duration);
            charging = false;
            //            lerpValue = 0;
            timer = 0;

            pulsing = true;
            yield return new WaitForSeconds(duration);
            pulsing = false;
            //            lerpValue = 0;

            timer = 0;
            duration -= 0.01f;
            if (duration < 0.01f)
            {
                if (finalStage)
                {
                    yield return new WaitForSeconds(2);
                    player.GetComponent<PlayerController>().health = 0;

                }
                else
                {
                    stageChange = false;
                    StartCoroutine(NextStage());
                }
            }
        }
    }



    public IEnumerator NextStage()
    {
        while(radius<radialLimit)
        {
            yield return new WaitForSeconds(0.0001f);
            radius += 0.5f;
            nextStage.SetActive(true);
            nextStage.gameObject.transform.localScale += new Vector3(0.021F, 0.021f, 0.021f);
        }
        player.GetComponent<PlayerController>().health -= (int)(player.GetComponent<PlayerController>().maxHp * 0.2f);
        nextStage.GetComponent<B42BasicBehavior>().health = health;
        for(int x = 0; x< spawnSpots.Length; x++)
        {
           GameObject clone = Instantiate(egg, spawnSpots[x].position, Quaternion.identity) as GameObject ;
            clone.transform.SetParent(trigger);
        }
    }




}
