using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMan : MonoBehaviour {
    public static ScoreMan scoreMan;
    public int score = 0;
    public int highScore = 0;
    public Text _score;
    public Text _highScore;
    private void Awake()
    {
        scoreMan = this;
    }
    
    public void SetScore(int score)
    {
        this.score += score;
        _score.text = this.score.ToString();
    }
    public void SetHigh()
    {
        this.highScore = this.score > this.highScore ? this.score : this.highScore;
        _highScore.text = this.highScore.ToString();
    }

}
