using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {


    [SerializeField]
    private int nextLevel;
    [SerializeField]
    private float speed;

    public void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * speed);
    }
public void OnTriggerEnter(Collider Other)
    {
        if(Other.tag == "Player")
        {
            Application.LoadLevel(nextLevel);
        }
    }
}
