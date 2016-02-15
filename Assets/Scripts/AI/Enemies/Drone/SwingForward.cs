using UnityEngine;
using System.Collections;

public class SwingForward : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform player;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void Update()
    {
        transform.LookAt(player.position);
    }
}
