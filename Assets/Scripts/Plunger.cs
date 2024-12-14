using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * The plunger script spawns new balls and launches them.
 * The plunger Script needs:
 * A ball prefab (assign in inspector)
 * A ball spawn transform (empty game object) assigned in the inspector
 * A ScoreKeeper Script on another game object tagged as "ScoreKeeper"
 * An Audio Source
 * 
 * If there is no ball in the scene the plunger can spawn a ball by pressing R. When the ball is in contact with the plunger
 * the player can hold the F key to pull back and release to launch the ball.
 * 
 */
public class Plunger : MonoBehaviour
{

    GameObject activeBall;
    public GameObject ballPrefab;
    public Transform ballSpawnPoint;
    public float force = 3000f;
    public bool ballExisits = false;
    bool ballContact = false;
    float pullback = 0.5f;
    AudioSource audio;
    ScoreKeeper scoreboard;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        scoreboard = GameObject.FindGameObjectWithTag("ScoreKeeper").GetComponent<ScoreKeeper>();

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r") && !ballExisits && scoreboard.numberOfBalls > 0)
        {
            SpawnBall();
        }

        if (ballExisits && ballContact)
        {

            if (Input.GetKeyUp("f"))
            {
                Launch();
            }
            else if (Input.GetKey("f"))
            {
                if (pullback <= 10f)
                {
                    pullback += Time.deltaTime;
                }
            }
        }
    }

    public void SpawnBall()
    {
        if (!ballExisits)
        {
            Debug.Log("SpawningBall");
            Instantiate(ballPrefab, ballSpawnPoint);
            ballExisits = true;
        }
    }

    /*
     * The ball will launch with more force the longer they player holds (pulls back) the plunger.
     */
    public void Launch()
    {
        if (ballExisits && ballContact)
        {
            Debug.Log("LaunchingBall");

            activeBall.GetComponent<Rigidbody>().AddForce(transform.forward* (force * pullback), ForceMode.Impulse);
            pullback = 0.5f;
            audio.Play();

        }
        else{
            Debug.Log("Ball Not in Contact");
        }
       
    }

    /*
     * The plunger will only interact with the ball if the ball is in contact with the plunger.
     */

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            Debug.Log("BallContact");
            activeBall = collision.gameObject;
            ballContact = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            Debug.Log("BallContact Lost");
            ballContact = false;
        }
    }

}
