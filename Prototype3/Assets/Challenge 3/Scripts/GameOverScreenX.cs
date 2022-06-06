using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //added
using UnityEngine.SceneManagement; //added

public class GameOverScreenX : MonoBehaviour
{

    public void RestartButton()
    {
        SceneManager.LoadScene("Challenge 3");
    }


}
