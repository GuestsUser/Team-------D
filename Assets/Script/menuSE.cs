using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class menuSE : MonoBehaviour
{

    [SerializeField] public AudioClip selectsound1;

    [SerializeField] public GameObject button1;

    [SerializeField] public GameObject button3;

    [SerializeField] private AudioSource audioselect;

    [SerializeField] private EventSystem eventsystem;

    [SerializeField] public GameObject th;

    void  Update()
    {

    }



    public void SE()
    {
        GameObject selected = eventsystem.currentSelectedGameObject.gameObject;
        if (1 == Input.GetAxis("Vertical"))
        {
            if (th != selected)
            {
                if (button1 != th)
                {
                    audioselect.Play();
                }
                th = selected;
            }
        }


        if (-1 == Input.GetAxis("Vertical"))
        {
            if (th != selected)
            {
                if (button3 != th)
                {
                    audioselect.Play();
                }
                th = selected;
            }
        }

    }
}


