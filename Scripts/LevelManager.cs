using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float _sceneLoadDelay = 2f;
    public void LoadGame()
    {
        StartCoroutine(WaitAndLoad("Game", _sceneLoadDelay));
        ScoreKeeper.GetInstance().ResetScore();
    }
    public void LoadMainMenu()
    {
        StartCoroutine(WaitAndLoad("MainMenu", _sceneLoadDelay));
    }
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", _sceneLoadDelay));
    }
    public void QuitGame()
    {
        Debug.Log("Quitting the game..");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

}
