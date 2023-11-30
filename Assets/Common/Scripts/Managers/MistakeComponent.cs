using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MistakeComponent : MonoBehaviour
{
    #region attributes

    private static TextMeshProUGUI _text;

    #endregion
   
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        ScoreController.OnMistakeChanged += UpdateMistakes;
    }

    private static void UpdateMistakes(int score)
    {
        _text.text = score.ToString();
    }
}
