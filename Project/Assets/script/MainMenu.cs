using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void StartGameClick () {
		SceneManager.LoadScene("Game");
	}

    public void QuitGameClick()
    {
        Debug.Log("Quit game.");
        Application.Quit();
    }
}
