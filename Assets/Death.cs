using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject ApeSphere;
    public GameObject StartPos;
    public Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "ApeSphere")
        {   
            Vector3 pos1 = StartPos.transform.position;
            ApeSphere.transform.position = pos1;
            print("death");
        }
        
    }
}
