﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public void PlayGame() {
		SceneManager.LoadScene("demo");	
	}
	
	public void QuitGame() {
		Application.Quit();
	}
}
