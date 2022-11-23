using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShot : MonoBehaviour
{
    private bool isOut = false;
    public GameObject theArrow = null;
    private Vector3 thePos = Vector3.zero;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (!PauseMenu.isPaused)
        {


            thePos = this.transform.position;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                isOut = true;
            }

            if (isOut)
            {
                GameObject cloneArrow = (GameObject)Instantiate(theArrow, thePos, Quaternion.identity);
                cloneArrow.transform.position = thePos;
                cloneArrow.transform.rotation = this.transform.rotation;
                isOut = false;
            }
        }
    }
}
