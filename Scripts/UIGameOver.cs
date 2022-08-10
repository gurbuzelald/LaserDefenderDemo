using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText;

    
    void Start()
    {
        _scoreText.text = ScoreKeeper.GetInstance().GetScore().ToString();
    }
}
