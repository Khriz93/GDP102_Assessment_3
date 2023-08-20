using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungScript : MonoBehaviour
{
    public AudioManager audioManager;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Ground"))
        {
            audioManager.DungSplatSound();
        }

        if (collision.CompareTag("Dung"))
        {
            audioManager.DungHitDungSound();
        }

        if (collision.CompareTag("PlayerNest"))
        {
            gameManager.playerScore++;
            gameObject.SetActive(false);
        }
    }



}
