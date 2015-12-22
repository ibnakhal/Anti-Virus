﻿using UnityEngine;
using System.Collections;

public class PayloadMovement : MonoBehaviour
{

    [SerializeField]
    private GameObject body = null;
    [SerializeField]
    private Vector3 vector = new Vector3(0, 0, 0);
    [SerializeField]
    private Transform direction = null;
    [SerializeField]
    public float force = 1f;

    [SerializeField]
    private int counter;
    [SerializeField]
    private int bombCounter;
    [SerializeField]
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


    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip moveClip;
    [SerializeField]
    private AudioClip triggerClip;
    [SerializeField]
    private AudioClip alarmClip;

    [SerializeField]
    private GameObject Explosion;
    [SerializeField]
    private GameObject Death;
    [SerializeField]
    private int dmg;


    [SerializeField]
    private float turnSpeedDelay;
    [SerializeField]
    private int turnCounter;
    [SerializeField]
    private bool moving = true;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private bool triggered = false;





    // Use this for initialization
    void Start()
    {
        source.clip = moveClip;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

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
    public void OnTriggerEnter(Collider Other)
    {
        if (!triggered)
        {

            if (Other.tag == "Player")
            {
                player = Other.transform;
                StartCoroutine(Looking());
                charging = true;

            }
        }
    }


    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("I HIT");
        Vector3 normal = collision.contacts[0].normal;

        Collider Other = collision.collider;

        if (Other.tag == "wall")
        {
            Debug.Log("WAll hit");
            //           Vector3 kiddy = Other.transform.FindChild("DIRECT").forward;
            vector = Vector3.Reflect(this.transform.forward, normal);
            this.transform.LookAt(this.transform.position + vector);
            Move();
        }
    }


    public void Move()
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime * force);
    }


    public void Kamikazee()
    {
        GameObject clone = Instantiate(Explosion, this.transform.position, this.transform.rotation) as GameObject;
        Destroy(this.gameObject);
    }
    public IEnumerator Looking()
    {
        if (!triggered)
        {
            StartCoroutine(Pulsation());
            triggered = true;
        }
        while (isActiveAndEnabled)
        {
            yield return new WaitForSeconds(turnSpeedDelay);
            for (int x = 0; x < turnCounter; x++)
            {
                Vector3 targeting = new Vector3(player.position.x, player.transform.position.y, player.position.z);
                this.transform.LookAt(targeting);

            }

        }
    }
    public IEnumerator Pulsation()
    {
        source.clip = alarmClip;
        source.loop = false;
        source.Play();
        yield return new WaitForSeconds(alarmClip.length);
        source.clip = triggerClip;
    
        while (isActiveAndEnabled)
        {
            if (duration <=0)
            {
                Kamikazee();
            }

            charging = true;
            yield return new WaitForSeconds(duration);
            charging = false;
            //            lerpValue = 0;
            timer = 0;
            source.Play();

            pulsing = true;
            yield return new WaitForSeconds(duration);
            pulsing = false;
            //            lerpValue = 0;

            timer = 0;
            duration -= 0.01f;

            if (force <= 8)
            {
                force += 0.5f;
            }
        }
    }

}
