using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArrowSpawner : MonoBehaviour
{

    [SerializeField] private float spawnTime;
    [SerializeField] GameObject[] movingArrowsPrefabs; //4 moving arrows prefabs (left, down, up, right)

    private bool readyToSpawn = true;



    void Start()
    {
        
    } 


    void Update()
    {
        if (readyToSpawn)
        {
            SpawnController();
        }
    }

    private void SpawnController()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        readyToSpawn = false;

        //Select one moving arrow type (up/down/left/right) at random
        int i = UnityEngine.Random.Range(0, 4); //0 inclusive, 4 exclusive
        GameObject arrowToSpawn = movingArrowsPrefabs[i];

        //Spawn it at (x,0) where x is the x-coordinate of its corresponding static arrow type
        Vector3 pos = GetSpawnPosition(arrowToSpawn);
        Instantiate(arrowToSpawn, pos, Quaternion.identity);

        //Repeat every spawnTime seconds
        yield return new WaitForSeconds(spawnTime);

        readyToSpawn = true;


    }

    private Vector3 GetSpawnPosition(GameObject arrowToSpawn)
    {
        
        int spawnedArrowDirection = ((int) arrowToSpawn.GetComponent<ArrowController>()?.GetDirection());

        GameObject[] staticArrows = GameObject.FindGameObjectsWithTag("Static Arrow");

        float xPos = 0;
        float yPos = 0;

        foreach (GameObject staticArrow in staticArrows)
        {
            int staticArrowDirection = ((int) staticArrow.GetComponent<StaticArrow>()?.GetDirection());
            if (staticArrowDirection == spawnedArrowDirection)
            {
                xPos = staticArrow.transform.position.x;
                yPos = -staticArrow.transform.position.y;
                break;
            }
        }

        return new Vector3(xPos, yPos);

    }
}
