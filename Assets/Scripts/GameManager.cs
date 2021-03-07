using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] ObjectPool ammoObjectPool;
    private int score = 0;

    private void Start()
    {
        // set score to 0
        SetScore(0);
    }
    // changes score by in value
    public void ChangeScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score;
    }
    // sets score to in value
    private void SetScore(int value)
    {
        score = value;
        scoreText.text = "Score: " + score;
    }

}
