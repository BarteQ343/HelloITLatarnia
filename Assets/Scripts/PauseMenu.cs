using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] GameObject pauseMenu;

	public void Resume()
	{
		pauseMenu.SetActive(false);
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		Time.timeScale = 1;
	}

	public void BackToMenu()
	{
		Application.Quit();
	}
}
