using UnityEngine;
using System.Collections;
using System;

public class NyxemBasicBehavior : MonoBehaviour {
    [SerializeField]
    private float speed, aStart, aEnd, lerpValue, timer, duration, hpP;
    [SerializeField]
    public bool speedUp = false, stage1 = true, stage2 = true;
    [SerializeField]
    private int[] hpThreshold;
    [SerializeField]
    private int hp, maxHp;
    [SerializeField]
    public GameObject minion, bullet;
    [SerializeField]
    protected Transform player;
    [SerializeField]
    public Transform[] spPoints;
    [SerializeField]
    private Stage1 s1;


    public virtual void Start()
    {
        aStart = speed;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        s1 = this.gameObject.GetComponent<Stage1>();


    }


	// Update is called once per frame
	public virtual void Update () 
    {
        this.transform.Rotate(Vector3.up * Time.deltaTime * speed);

        hpP = (((float)hp / (float)maxHp) * 100);

        speed = Mathf.Lerp(aStart, aEnd, lerpValue);
	

        if (hpP <= hpThreshold[0] && stage1)
        {
            speedUp = true;

        }
        if (hpP <= hpThreshold[1] && stage2)
        {
            
            speedUp = true;

        }

        if (speedUp)
        {
            timer += Time.deltaTime;

            lerpValue = (timer / duration);
            if (lerpValue >= 1)
            {
                speedUp = false;
                lerpValue = 0;
                timer = 0;
                aStart = aEnd;
                aEnd *= 2;
                StageChange();
            }
        }
      }

    public void StageChange()
    {
       
        if (hpP <= hpThreshold[0] && stage1)
        {
            stage1 = false;
            s1.StageChanger();
        }
        if (hpP <= hpThreshold[1] && stage2)
        {
            stage2 = false;
            s1.StageChanger();
        }
    }

    public void GetHurt(int damage)
    {
        hp -= damage;
    }
}
