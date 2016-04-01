/*************************
--------------------------
|*   PlayerController.cs*|
|*   Ibrahim Nakhal     *|
|*   Student            *|
|*   AAU Game Design    *|
--------------------------
*************************/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// Enforces attatchment of required component
[RequireComponent(typeof(CharacterMover))]
public class PlayerController : MonoBehaviour 
{
    //Variables being declared
    [SerializeField] 
    public float jumpSpeed = 15.0f, runSpeed = 3.0f, turnSpeed = 180.0f, jSet,rSet,tSet,jTro = 9f,rTro=2f,tTro=100.0f, spawnTimer;
    [SerializeField]
    private string forwardBackInput = "Vertical", leftRighInput = "Horizontal";
    [SerializeField]
    private CharacterMover mover = null;
    [SerializeField]
    public int health, maxHp, warningShowLimit,gameOver, cryoHit, cryoMax;
    [SerializeField]
    public bool trojand = false, trojan1 = false;
    [SerializeField]
    private Text txt, hTxt;
    [SerializeField]
    private GameObject spawn;
    [SerializeField]
    private GameObject diseases;
    /// <summary>
    /// On level start retrieves reference to the CharacterMover to ensure communication between the two scripts
    /// </summary>
    public void Start()
    {
        mover = this.GetComponent<CharacterMover>();
        jSet = jumpSpeed;
        rSet = runSpeed;
        tSet = turnSpeed;
        txt.enabled = true;
        txt.text = "";
       // StartCoroutine(Spawned(spawnTimer));

    }

    public IEnumerator Spawned(float time)
    {
        yield return new WaitForSeconds(time);
        spawn.SetActive (false);
    }


    /// <summary>
    /// Applies referenced inputs to the referenced mover
    /// </summary>
    public void Update()
    {
        //ensures that the player does not exponentially increase speed
        mover.ZeroOutVelocity();

        if (Input.GetKey(KeyCode.Space))
        {
            mover.Jump(jumpSpeed);
        }

        // Compresses inputs with modified speeds to a single variable
        float forwardBack = Input.GetAxis(forwardBackInput) * runSpeed;
        float leftRight = Input.GetAxis(leftRighInput) * runSpeed;

        mover.Move(forwardBack, leftRight);

        float hpPercent = (((float)health/(float)maxHp)*100);
        hpPercent = Mathf.Round(hpPercent * 1f) / 1f;

        hTxt.text = ("Memory Space : " + hpPercent + "%");


        if(cryoHit >= cryoMax)
        {
            //SCREEN MELTING GOES HERE
            health = 0;
        }

        if (hpPercent < 50)
        {
            hTxt.color = Color.yellow;
            
            if (hpPercent < 25)
            {
                hTxt.color = Color.red;
            }
        }
        else
        {
            hTxt.color = Color.green;
        }


       /* if(trojand)
        {
            if (!trojan1)
            {
                Trojan();

                StartCoroutine(Warner("TROJAN DETECTED"));
                trojan1 = true;
            }
        }
        else
        {
            
            turnSpeed = tSet;
            runSpeed = rSet;
            jumpSpeed = jSet;
            trojan1 = false;
            trojand = false;
        }*/ 

        if(health>maxHp)
        {
            health = maxHp;
        }
        if(health <= 0)
        {
            Application.LoadLevel(gameOver);
        }
    }

    public void HealUp(int hp)
    {
        health = health + hp;
        DiseaseClean();
        StartCoroutine(Warner("PROGRAM UPDATED"));
    }

    public void MaxUp(int max)
    {
        maxHp = maxHp + max;
        health += maxHp;
        DiseaseClean();
        StartCoroutine(Warner("SECURITY UPDATE INSTALLED"));
    }


    public void Troj()
    {
        diseases.GetComponent<Trojan>().Infect();

    }
    public IEnumerator Warner(string message)
    {
        Debug.Log(message);
            
            txt.text = message;

            
            yield return new WaitForSeconds(1);
            txt.text = "";
            yield return new WaitForSeconds(1);
            txt.text = message;
            yield return new WaitForSeconds(1);
            txt.text = "";
            yield return new WaitForSeconds(1);
            txt.text = message;
            yield return new WaitForSeconds(1);
            txt.text = "";
    }
    
    public void Ouch(int damage)
    {
        health -= damage;
    }

    public void Mal()
    {
        diseases.GetComponent<Malware>().Infect();
    }
    public void Ad()
    {
        diseases.GetComponent<Adware>().Infect();

    }

    public void DiseaseClean()
    {
        trojand = false;
        diseases.GetComponent<Malware>().Maled = false;
        diseases.GetComponent<Adware>().triggered = false;
        diseases.GetComponent<Trojan>().trojan = false;

    }


}
