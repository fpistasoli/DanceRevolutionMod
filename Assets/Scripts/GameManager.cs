using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int bonusPoints;
    private int score = 0;
    public static GameManager sharedInstance;

    //Events
    public static event Action onScoreChanged;

    private void Awake() //SINGLETON
    {
        if (sharedInstance == null)
        {
            sharedInstance = this; //this se refiere a la instancia de esta clase
            score = 0;
            DontDestroyOnLoad(gameObject); //para que el objeto GameManager, que tiene a esta clase como componente, persista de escena en escena
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log("SCORE: " + score);   
    }


    public void EarnPoints()
    {
        score += bonusPoints;
        onScoreChanged?.Invoke();
    }

    public int GetScore()
    {
        return score;
    }




}
 