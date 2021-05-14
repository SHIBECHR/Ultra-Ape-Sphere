using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuVictory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void StartGame()//for menu to load into game
	{
        SceneManager.LoadScene("SampleScene");
    }
    public void VictoryScreen()//for when you reah the end of the maze, this take you back to menu
    {
        SceneManager.LoadScene("MenuScene");
    }
    void OnCollisionEnter(Collision collision)//detects collision between the End cube and the player
	{
        if (collision.gameObject.tag == "ApeSphere")//ApeSphere is what i tagged the player before i had changed the game, decided to keep it
        {
            VictoryScreen();
        }
    }
}
