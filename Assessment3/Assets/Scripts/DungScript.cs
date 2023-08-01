using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungScript : MonoBehaviour
{
    public AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
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
    }



}
