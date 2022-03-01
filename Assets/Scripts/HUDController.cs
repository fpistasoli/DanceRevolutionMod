using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{

    [SerializeField] private Text scoreValue;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.onScoreChanged += onScoreChangeHandler;
        
    }

    private void onScoreChangeHandler()
    {
        scoreValue.text = GameManager.sharedInstance.GetScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnDestroy()
    {
        GameManager.onScoreChanged -= onScoreChangeHandler;
    }


}
