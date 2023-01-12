using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{
    public void playAgainButton()
    {
        SceneManager.LoadScene("GameMain");
        Time.timeScale = 1;
    }
}
