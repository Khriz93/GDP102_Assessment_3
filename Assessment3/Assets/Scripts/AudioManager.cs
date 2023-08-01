using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    public List<AudioClip> gameMusic = new List<AudioClip>();
    public List<AudioClip> dungSpawn = new List<AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
        audioSource.PlayOneShot(gameMusic[0]);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
