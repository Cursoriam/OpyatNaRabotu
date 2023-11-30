using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class ScoreController : MonoBehaviour
{
    #region const

    private const int TotalMistakesCount = 3;

    #endregion
    
    #region attributes

    private static int _mistakesCount;
    private static int _score;
    private static ScoreController _instance;

    #endregion

    public delegate void ScoreEventHandler(int score);
    public static event  ScoreEventHandler OnScoreChanged;
    public delegate void MistakeEventHandler(int mistakes);
    public static event MistakeEventHandler OnMistakeChanged;
    public delegate void GameOverEventHandler();
    public static event GameOverEventHandler OnGameOver;

    public static int MistakesCount
    {
        get => _mistakesCount;
        set
        {
            _mistakesCount = value;
            OnMistakeChanged?.Invoke(_mistakesCount);
            if (_mistakesCount <= 0)
            {
                _instance.StartCoroutine(GameOver());
            }
        }
    }
    
    public static int Score
    {
        get => _score;
        set
        {
            _score = value;
            OnScoreChanged?.Invoke(_score);
        }
    }

    private void Awake()
    {
        _instance = this;
        MistakesCount = TotalMistakesCount;
    }
    
    private static IEnumerator GameOver()
    {
        GameObject gameOverScreen = GameObject.Find("GameOverNode").transform.Find("GameOverScreen").gameObject;
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>().Where(go => (go.GetComponent<RectTransform>() == null && 
            go.GetComponent<Camera>() == null && !go.name.Contains("GameOverNode")))) {
            Destroy(o);
        }
        gameOverScreen.SetActive(true);
        gameOverScreen.transform.position = new Vector3(gameOverScreen.transform.position.x, gameOverScreen.transform.position.y, gameOverScreen.transform.position.z - 9);
        yield return new WaitForSeconds(1.0f);
        Time.timeScale = 0;
    }
}
