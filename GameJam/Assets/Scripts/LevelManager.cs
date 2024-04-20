using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int currentLevel = 1;
    [SerializeField] GameObject levelCompletedScreen;
    public static LevelManager instance;
    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void LevelCompleted()
    {
        levelCompletedScreen.SetActive(true);
    }
    public void LoadNextLevel()
    {
        currentLevel++;
        SceneManager.LoadScene("Level" + currentLevel);
        levelCompletedScreen.SetActive(false);
    }
    public bool LevelCompletedScreenActive()
    {
        return levelCompletedScreen.activeSelf;
    }
    public void SetLevelCompletedScreenActive(bool value)
    {
        levelCompletedScreen.SetActive(value);
    }
}
