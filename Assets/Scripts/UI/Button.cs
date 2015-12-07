/************************
-------------------------
|*   Button.cs         *|
|*   Ibrahim Nakhal    *|
|*   Student           *|
|*   AAU Game Design   *|
-------------------------
************************/
using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{
    [SerializeField]
    private int LevelNo;
    [SerializeField]
    private bool MenuLeaver;
    [SerializeField]
    private AudioClip click;
    [SerializeField]
    private AudioClip mouseOver;


    public void LoadLevel()
    {
        if (GameObject.FindGameObjectWithTag("AudioMachine") != null && MenuLeaver == true)
        {
            Destroy(GameObject.FindGameObjectWithTag("AudioMachine"));
        }

        Application.LoadLevel(LevelNo);
    }

    public void Quiter()
    {
        Application.Quit();
    }
}