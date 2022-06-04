using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeCollector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D target1)
    {
        if(target1.tag == "PipeScore")
        {
            Destroy(target1.gameObject);
        }
    }
}
