using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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



        Invoke("Spawn", 0.3f);

    }
    public void Spawn()
    {
        SceneManager.LoadScene(0);
    }
}
