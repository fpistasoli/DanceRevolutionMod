using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{

    public enum directionType {left, down, up, right};

    [SerializeField] private directionType direction;


    void Start()
    {
       

    }


    void Update()
    {
        
    }

    public directionType GetDirection()
    {
        return direction;
    }



}
