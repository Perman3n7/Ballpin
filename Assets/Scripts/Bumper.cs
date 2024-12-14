using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* The Bumper script is for bumpers on the pinball table. To work properly it will need:
 * A bumper value set in the inspector.
 * A game object named "Ichosphere" as a child of the bumper.
 * A Material named "ScoreZoneOn" in the Resources folder.
 * A ScoreKeeper script on an object tagged as "ScoreKeeper"
 * An audio source on the Bumper game object.
 * 
 * How it works: 
 * When the ball hits the bumper it will bouce off the bumper via physics material.
 * The bumper will use the ScoreKeeper's addPoints() function to add points
 * The Icosphere's material will change to "light up" for a second.
 * 
 * About the Icosphere:
 * I made an icosphere using probuilder, the game object that lights up can be any 3D model that has a mesh render.
 * Make sure to change the name in the lightBall assignment in the Start() function to match the name of the new model.
 * 
 */
public class Bumper : MonoBehaviour
{
    public float bumperValue;
    ScoreKeeper scoreboard;
    AudioSource audio;
    Material inactiveMat;
    Material activeMat;
    MeshRenderer lightBall;
   
    void Start()
    {
        activeMat = Resources.Load("Materials/ScoreZoneOn", typeof(Material)) as Material;
        audio = GetComponent<AudioSource>();
        scoreboard = GameObject.FindGameObjectWithTag("ScoreKeeper").GetComponent<ScoreKeeper>();
        lightBall = gameObject.transform.Find("Icosphere").GetComponentInParent<MeshRenderer>(); 
        inactiveMat = lightBall.material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            audio.Play();
            scoreboard.addPoints(bumperValue);
            StartCoroutine("LightUp");
        }
    }

    IEnumerator LightUp()
    {
        lightBall.material = activeMat;
        yield return new WaitForSeconds(1f);
        lightBall.material = inactiveMat;
    }

}
