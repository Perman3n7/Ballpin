using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* This script rotates the camera around a game object. 
 * To use: 
 * Attach this script to an Empty GameObject that will act as a "Focus"
 * Move the MainCamera in the hiarchy so it is a child of the Focus.
 * Adjust rotate speed as needed.
 */
public class CameraRotate : MonoBehaviour
{
    public float rotateSpeed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }
}
