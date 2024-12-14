using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The ScoreZone script controls a game object that will give the player points when the ball passes though a score zone.
 * To use this script attach it to a game object with a 3D collider set to be a trigger.
 * Give the ScoreZone a value in the inspector.
 * 
 * ScoreZone Needs: 
 * A ScoreKeeper script on a GameObject tagged as "ScoreKeeper"
 * A material call ScoreZoneOn inside the Materials folder in the Resources folder. (Resources/Materials/ScoreZoneOn)
 * An Audio listener on this game object.
 */

public class Scorezone : MonoBehaviour
{
    public float value;
    ScoreKeeper scoreboard;

    Material inactiveMat;
    Material activeMat;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        inactiveMat = gameObject.GetComponent<MeshRenderer>().material;
        activeMat = Resources.Load("Materials/ScoreZoneOn", typeof(Material)) as Material;
        scoreboard = GameObject.FindGameObjectWithTag("ScoreKeeper").GetComponent<ScoreKeeper>();
        audio = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            scoreboard.addPoints(value);
            StartCoroutine("LightUp");
        }
    }

    IEnumerator LightUp()
    {
        audio.Play();
        gameObject.GetComponent<MeshRenderer>().material = activeMat;
        yield return new WaitForSeconds(3f);
        gameObject.GetComponent<MeshRenderer>().material = inactiveMat;
    }


}
