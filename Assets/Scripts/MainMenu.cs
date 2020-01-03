using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    
   
	// Use this for initialization
	public void onClick () {
       
            SceneManager.LoadScene(3);
            
        }
    public void Equip()
        {
            SceneManager.LoadScene(4);
            
        }
    public void Setting()
        {
            SceneManager.LoadScene(5);
           
        }
    public void Quit()
        {
            Application.Quit();
        
        }
     public void Back()
    {
        SceneManager.LoadScene(2);
    }
     public void Help()
    {
        SceneManager.LoadScene(6);
    }
    public void Help_2()
    {
        SceneManager.LoadScene(7);
    }
    public void Help_3()
    {
        SceneManager.LoadScene(8);
    }
    public void Help_4()
    {
        SceneManager.LoadScene(9);
    }
    public void Help_5()
    {
        SceneManager.LoadScene(10);
    }
    public void Boss()
    {
        SceneManager.LoadScene(11);
    }
    public void Credits()
    {
        SceneManager.LoadScene(12);
    }
    public void Difficulty()
    {
        SceneManager.LoadScene(13);
    }
}
