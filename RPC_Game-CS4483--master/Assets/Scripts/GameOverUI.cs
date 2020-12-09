﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{

    public void Quit()
    {
        Application.Quit();
    }
    
    public void Restart()
    {
        SceneManager.LoadScene("demo");
    }
}
