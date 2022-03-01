using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StaticArrow : ArrowController
{

    [SerializeField] private bool isKeyPad;

    private Camera cam;
    GameObject movingCorrespondingArrow = null;

    Ray raycast;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfPressed();
    }

    private void CheckIfPressed()
    {
        if (isKeyPad)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            raycast = cam.ScreenPointToRay(touchPosition);
            RaycastHit hit;

            if (Physics.Raycast(raycast, out hit))
            {
                if(hit.collider.gameObject == this.gameObject)
                {
                    if(PressedAtArrowMatch()) //pressed when moving and static arrows match (same direction)
                    {
                        GameManager.sharedInstance.EarnPoints();
                        Destroy(movingCorrespondingArrow);
                    }
                }
            }
            
        }
    }

    private bool PressedAtArrowMatch()
    {
        //if static and moving corresponding arrows are overlapping,
        GameObject[] movingArrows = GameObject.FindGameObjectsWithTag("Arrow");

        foreach(GameObject movingArrow in movingArrows)
        {
            if( ((int) movingArrow.GetComponent<ArrowController>()?.GetDirection()) == ((int) GetDirection()))
            {
                movingCorrespondingArrow = movingArrow;
            }
        }

        if (movingCorrespondingArrow == null) { return false; }

        return movingCorrespondingArrow.GetComponent<MovingArrow>().MatchingArrows();

    }

    public bool IsKeyPad()
    {
        return isKeyPad;
    }



    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(raycast);
    }
    */

}
