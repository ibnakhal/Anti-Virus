using UnityEngine;
using System.Collections;

public class B42BasicBehavior : MonoBehaviour {



    [SerializeField]
    private int CountdownTime;
    [SerializeField]
    private GameObject nextStage;
    [SerializeField]
    private int health;

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
    private bool charging, pulsing;

    // Use this for initialization
    void Start () {

        StartCoroutine(Countdown());


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

            yield return new WaitForSeconds(1);


            pulsing = true;
            yield return new WaitForSeconds(duration);
            pulsing = false;
            //            lerpValue = 0;

            timer = 0;
            duration -= 0.01f;
            Debug.Log(CountdownTime - x);
        }
        Debug.Log("TIME!");
    }







}
