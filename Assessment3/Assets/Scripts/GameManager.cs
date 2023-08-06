using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float gameTime = 0;
    private bool hasEnemy = false;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameTimer());
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GameTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            gameTime++;
            print("Game Time = " + gameTime.ToString());
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (hasEnemy == false)
        {
            yield return new WaitForSeconds(5);
            Instantiate(enemy, new Vector3(0, 5, 0), Quaternion.identity);
            hasEnemy = true;
        }
    }

}
