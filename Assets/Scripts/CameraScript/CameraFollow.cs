using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform bird;
    
    public float offsetX = 0;



    void Awake()
    {
        bird = GameObject.Find("bird").transform;
    }


    void Update()
    {
        transform.position = new Vector3(bird.position.x + offsetX, 0 , transform.position.z); 
    }
}
