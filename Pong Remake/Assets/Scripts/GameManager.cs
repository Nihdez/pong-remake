using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{

    private int leftScore;
    private int rightScore;

    [SerializeField] TextMeshProUGUI leftScoreText;
    [SerializeField] TextMeshProUGUI rightScoreText;

    private void Awake()
    {
        leftScoreText = GameObject.Find("LeftScoreText").GetComponent<TextMeshProUGUI>();
        rightScoreText = GameObject.Find("RightScoreText").GetComponent<TextMeshProUGUI>();
        SetupScore();
    }

    void Start()
    {

    }

    void Update()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();
    }

    private void SetupScore()
    {
        leftScore = 0;
        rightScore = 0;
        UpdateScore();
    }


    public void ScoreUp(bool isLeftScore)
    {
        if (isLeftScore)
        {
            leftScore += 1;
        }
        else
        {
            rightScore += 1;
        }
    }
}
