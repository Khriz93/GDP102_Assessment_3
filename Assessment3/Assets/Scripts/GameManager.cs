using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float gameTime = 300;
    public int playerScore = 0;
    private bool hasEnemy = false;
    public GameObject enemy;
    public TMP_Text playerScoreText;
    public TMP_Text gameTimeText;
    public TMP_Text gameMessage;
    public TMP_Text finText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameTimer("Time: "));
        StartCoroutine(SpawnEnemy());
        StartCoroutine(StartMessage("Collect 5 dung before the timer runs out!!!"));
        finText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerScore("Score: ");
        LevelEnd();
    }

    IEnumerator GameTimer(string messagePrefix)
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            gameTime-= 1;
            gameTimeText.text = messagePrefix + gameTime.ToString();
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

    IEnumerator StartMessage(string messagePrefix)
    {
        while (gameTime > 290)
        {
            yield return new WaitForSeconds(1);
            gameMessage.text = messagePrefix;
        }
    }

    public void PlayerScore(string messagePrefix)
    {
        playerScoreText.text = messagePrefix + playerScore.ToString();
    }

    public void LevelEnd()
    {
        if (playerScore == 5)
        {
            finText.gameObject.SetActive(true);
            finText.text = "YOU WIN!";
        }

        if (gameTime == 0)
        {
            finText.gameObject.SetActive(true);
            finText.text = "YOU LOSE!";
        }
    }

}
