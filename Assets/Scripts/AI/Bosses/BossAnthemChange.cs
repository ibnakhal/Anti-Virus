using UnityEngine;
using System.Collections;

public class BossAnthemChange : MonoBehaviour {
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip musicClip;
    [SerializeField]
    private AudioClip klaxClip;
    [SerializeField]
    private bool spent;
    public void Start()
    {
        source = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }

    public void OnTriggerEnter (Collider Other)
    {
        if(Other.tag == "Player" && !spent)
        {
            StartCoroutine(MusicPlay());
            spent = true;
        }

    }

    public IEnumerator MusicPlay()
    {
        source.clip = klaxClip;
        source.Play();
        yield return new WaitForSeconds(1);
        source.clip = musicClip;
        source.Play();
    }
}
