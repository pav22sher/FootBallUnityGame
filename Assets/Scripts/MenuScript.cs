﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
	public void StartGame()
	{
		SceneManager.LoadScene("SampleScene");
	}
}