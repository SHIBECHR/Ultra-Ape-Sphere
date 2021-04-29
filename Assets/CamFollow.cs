using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject player1;
    public float CameraDistanceOnZ = -3f;
    public float CameraHeight = 1f;

    public float mouseSpeed = 3;
    public Transform player;
    public Camera yourCam;

    public float turnspeed = 10;

    public Transform to;
    public Transform from;
    public float speed = 2;

    public GameObject parent;
    public GameObject child;
    public DetectCollision barrier;

    float t = 0.0f;
    float t2 = 0.0f;

    private void FixedUpdate()
    {
        float X = Input.GetAxis("Mouse X") * mouseSpeed;
        float Y = Input.GetAxis("Mouse Y") * mouseSpeed;

        parent.transform.RotateAround(player.transform.position, Vector3.up, -X); // Player rotates on Y axis, your Cam is child, then rotates too

        //to.transform.Rotate(0, X, 0); // Player rotates on Y axis, your Cam is child, then rotates too
        player.transform.Rotate(-Y / 100f, 0, 0);

        // To scurity check to not rotate 360º 
        if (yourCam.transform.eulerAngles.x + (-Y) > 80 && yourCam.transform.eulerAngles.x + (-Y) < 280)
        { 

        }
        else
        {
            yourCam.transform.RotateAround(player.position, yourCam.transform.right, -Y);
        }
    }

    void Update()
    {
        Vector3 pos = player1.transform.position;
        pos.z += CameraDistanceOnZ;
        transform.position = pos;
        pos.y += CameraHeight;
        transform.position = pos;
        Tilter();
        TilterV2();
    }

    // On key release, resets rotation slowly
    public void Tilter()
    {
        if (Input.GetKey(KeyCode.W))
        {
            t = 0.0f;
        }
        else
        {
            t += Time.deltaTime * speed;
        }

        child.transform.localRotation = Quaternion.Lerp(child.transform.localRotation, to.rotation, t);
    }

    // On key press, tilts the plane
    public void TilterV2()
    {

        if (Input.GetKey(KeyCode.W))
        {
            t2 = 0.1f;
        }
        else
        {
            t2 = 0.0f;
        }

        if(!barrier.hit)
        {
            child.transform.RotateAround(player.transform.position, Vector3.right, t2);
        }

       // print(child.GetComponent<Rigidbody>().velocity);
        
    }



}
