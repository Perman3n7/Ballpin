using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * This script lets the player shake the table. 
 * To use make sure this script is on the table game object and that all parts of the 
 * table are children of the table game object.
 */
public class ShakeTable : MonoBehaviour
{
 
    void Update()
    {
        if (Input.GetKey("x"))
        {
            StartCoroutine(Shake(true));
        } else if (Input.GetKey("z"))
        {
            StartCoroutine(Shake(false));
        }
    }

    IEnumerator Shake(bool right)
    {
        if (right)
        {
            transform.Rotate(transform.right, 2f * Time.deltaTime);
            yield return new WaitForSeconds(.2f);
            transform.Rotate(-transform.right, 2f * Time.deltaTime);
        } 
        else
        {
            transform.Rotate(transform.up, 2f * Time.deltaTime);
            yield return new WaitForSeconds(.2f);
            transform.Rotate(-transform.up, 2f * Time.deltaTime);
        }
    }
}
