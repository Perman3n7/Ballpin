using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMenu : MonoBehaviour
{

    GameObject controlOpen;
    GameObject controlClose;
    
    // Start is called before the first frame update
    void Start()
    {
        controlOpen = GameObject.FindGameObjectWithTag("ControlButton");
        controlClose = GameObject.FindGameObjectWithTag("Controls");
        controlClose.SetActive(false);
    }


    public void controlButtonOpen()
    {
        controlClose.SetActive(true);
        controlOpen.SetActive(false);
    }

    public void controlButtonClose()
    {
        controlOpen.SetActive(true);
        controlClose.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
