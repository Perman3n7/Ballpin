using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The Killball script will destroy a ball on contact. 
 * Points are deducted using the addPoints() function on the scorekeeper.
 * The plunger is notified that the ball no longer exhists using the ballExists variable.
 * 
 * Be sure to asign a penalty value in the inspector.
 * 
 */

public class KillBall : MonoBehaviour
{
    ScoreKeeper scoreboard;
    Plunger plunger;
    AudioSource audio;
    public float penalty;
    private void Awake()
    {
        scoreboard = GameObject.FindGameObjectWithTag("ScoreKeeper").GetComponent<ScoreKeeper>();
        plunger = GameObject.FindGameObjectWithTag("Plunger").GetComponent<Plunger>();
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            audio.Play();
            scoreboard.addPoints(penalty);
            scoreboard.changeBallAmount(-1f);
            plunger.ballExisits = false;
            Destroy(other.gameObject); 
        }
    }
}
