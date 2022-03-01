using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingArrow : ArrowController
{

    [SerializeField] private float speed;

    private Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        DestroyIfOutOfSight();

    }

    private void DestroyIfOutOfSight()
    {
        if (cam.WorldToViewportPoint(transform.position).y > 1)
        {
            Destroy(gameObject);
        }

    }

    private void Move()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
    }
}
