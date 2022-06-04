using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    private Rigidbody2D mybody;
    public float jumpForce;
    public float rotation;
    public float xspeed;
    [HideInInspector]
    public bool HasStarted = false;
    public bool HasDied = false;
    public int scoreCount = 0;
    public Text score;
    private Vector3 birdRotation;
    public AudioClip scoreClip, deathClip, flapClip, pipeHitClip; 

    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if(HasStarted && !HasDied)
        {
            jumpMovement();
            BirdRotation();
            xMovement();
        }
        else
        {
            if (mybody.velocity.y < -1 && !HasDied)
            {
                mybody.velocity = Vector2.up * jumpForce * 0.365f;
            }
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                HasStarted = true;
                if(!HasDied)
                    mybody.velocity = Vector2.up * jumpForce;
            }
        }
        if (HasDied)
        {
            GetComponent<Animator>().enabled = false;
            //GetComponent<>().enabled = false;
        }
    }

    void jumpMovement()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            mybody.velocity = Vector2.up * jumpForce;
            AudioSource.PlayClipAtPoint(flapClip, transform.position);
        }
    }

    void xMovement()
    {
        transform.position += new Vector3(Time.smoothDeltaTime * xspeed, 0);
    }

    void BirdRotation()
    {
        float DegreesToAdd = 0;
        if(mybody.velocity.y <= 0)
        {
            DegreesToAdd = -1 * rotation ;
        }
        if (mybody.velocity.y > 0)
        {
            DegreesToAdd = 2 + rotation;
        }
        birdRotation = new Vector3(0, 0, Mathf.Clamp(birdRotation.z + DegreesToAdd, -70, 30));
        transform.eulerAngles = birdRotation;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "PipeHit")
        {
            if(!HasDied)
            {
                AudioSource.PlayClipAtPoint(pipeHitClip, transform.position);
            }
            HasDied = true;
        }
        if (target.tag == "PipeScore")
        {
            scoreCount ++;
            score.text = scoreCount.ToString();
            PlayerPrefs.SetInt("scoreCount", scoreCount);
            AudioSource.PlayClipAtPoint(scoreClip, transform.position);
        }
    }

    private void OnCollisionEnter2D(Collision2D target1)
    {
        if(target1.gameObject.tag == "GroundHit")
        {
            if (!HasDied)
            {
                AudioSource.PlayClipAtPoint(deathClip, transform.position);
            }
            HasDied = true;
        }
    }

}
