using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public bool gamePaused = false;
	public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (gamePaused == true)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
    }

	public void Resume()
	{
		gamePaused = false;
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Pause()
	{
		gamePaused = true;
		pauseMenuUI.SetActive(true);
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Time.timeScale = 0f;
	}

	public void LoadMenu()
	{
		Time.timeScale = 1f;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		SceneManager.LoadScene("TEST");
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
