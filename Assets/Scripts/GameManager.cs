using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameWinCanvas;

    public void Start()
    {
        Time.timeScale = 1;
        Score.score = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
        TrackScore();
    }

    public void TrackScore()
    {
        if(Score.score >= 10)
        {
            Cursor.visible = true;
            GameWin();
        }
    }

    public void GameWin()
    {
        gameWinCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
