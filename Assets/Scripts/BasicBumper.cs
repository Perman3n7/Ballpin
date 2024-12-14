using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* The Bumper script is for bumpers on the pinball table. To work properly it will need:
 * A bumper value set in the inspector.
 * A ScoreKeeper script on an object tagged as "ScoreKeeper"
 * An audio source on the Bumper game object.
 * 
 * How it works: 
 * When the ball hits the bumper it will bouce off the bumper via physics material.
 * The bumper will use the ScoreKeeper's addPoints() function to add points
 */
public class BasicBumper : MonoBehaviour
{
    public float bumperValue;
    ScoreKeeper scoreboard;
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        scoreboard = GameObject.FindGameObjectWithTag("ScoreKeeper").GetComponent<ScoreKeeper>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            audio.Play();
            scoreboard.addPoints(bumperValue);
        }
    }
}
