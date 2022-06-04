using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Bird bird;
    public GameObject pipe;
    public float timerMin, timerMax;
    public float yBounceMin, yBounceMax;
    private bool startSpawning;


    void Awake()
    {
        bird = GameObject.FindObjectOfType<Bird>();
    }

    
    // Update is called once per frame
    void Update()
    {
        if(bird.HasStarted && !startSpawning)
        {
            StartCoroutine(SpawnPipe());
            startSpawning = true;
        }

        if(bird.HasDied)
        {
            StopAllCoroutines();
        }
    }

    IEnumerator SpawnPipe()
    {
        yield return new WaitForSeconds(Random.Range(timerMin, timerMax));
        Instantiate(pipe, 
                    new Vector2(transform.position.x, Random.Range(yBounceMin, yBounceMax)),
                    Quaternion.identity);
        StartCoroutine(SpawnPipe());
    }

}
