using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //added
using UnityEngine.UI; //added

//NOTE: Script not in use

public class RestartControlX : MonoBehaviour
{
   

    public void ResetTheGame()
    {
        
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // print("The button is working");
        
    }
}
