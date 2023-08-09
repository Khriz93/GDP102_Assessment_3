using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float gameTime = 0;
    public int playerScore = 0;
    private bool hasEnemy = false;
    public GameObject enemy;
    public TMP_Text playerScoreText;
    public TMP_Text gameTimeText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameTimer("Time: "));
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GameTimer(string messagePrefix)
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            gameTime++;
            gameTimeText.text = messagePrefix + gameTime.ToString();
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
