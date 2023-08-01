using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungManager : MonoBehaviour
{
    // Spawns dung from the sky within a random area in the centre of the map
    public GameObject dung;
    private Transform spawnPosition;
    public List<Transform> spawnPoints = new List<Transform>();
    public GameManager gameManager;
    public AudioManager audioManager;
    private float spawnMin = 2f;
    private float spawnMax = 5f;



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        StartCoroutine(DungSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DungSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range((float)spawnMin, spawnMax));
            spawnPosition = spawnPoints[Random.Range(0, spawnPoints.Count)];
            Instantiate(dung, spawnPosition.position, Quaternion.identity);
            audioManager.DungSpawnSound();
        }
    }

}
