using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DetectDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       
    }
    void OnCollisionEnter(Collision collision)//detects collision between the End cube and the player
    {
        if (collision.gameObject.tag == "ApeSphere")//ApeSphere is what i tagged the player before i had changed the game, decided to keep it
        {
            //Invoke("Spawn", 5);
        }
		else
		{
            Invoke("Spawn", 5);
        }
    }
    public void Spawn()
	{
        SceneManager.LoadScene(0);
    }
}
