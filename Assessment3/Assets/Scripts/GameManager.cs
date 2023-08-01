using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float gameTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameTimer());
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

}
