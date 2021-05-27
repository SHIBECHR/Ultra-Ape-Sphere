using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public bool hit = false;

	private void OnCollisionEnter(Collision collision)
    {
        hit = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        hit = false;
    }
}
