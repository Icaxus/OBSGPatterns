using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextController : MonoBehaviour
{
    private Text _scoreText;
    public Text ScoreText { get { return (_scoreText == null) ? _scoreText = GetComponent<Text>() : _scoreText; } }

    private void Start()
    {
        UpdateScoreText();
    }

    private void OnEnable()
    {
        EventManager.OnCoinPickUp.AddListener(UpdateScoreText);
    }

    private void OnDisable()
    {
        EventManager.OnCoinPickUp.RemoveListener(UpdateScoreText);
    }

    private void UpdateScoreText()
    {
        int point = FindObjectOfType<Player>().point;
        ScoreText.text = "Score: " + point;
    }
}
