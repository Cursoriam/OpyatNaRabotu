using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreComponent : MonoBehaviour
{
   #region attributes

   private static TextMeshProUGUI _text;

   #endregion
   
   private void Awake()
   {
      _text = GetComponent<TextMeshProUGUI>();
      ScoreController.OnScoreChanged += UpdateScore;
   }

   private static void UpdateScore(int score)
   {
      _text.text = score.ToString();
   }
}
