using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManger : MonoBehaviour {
    public static int Score=0;
    public Text score;
	// Use this for initialization
	void Start () {
        Score = -1;
        score.text = "Score:" + Score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        score.text = "Score:" + Score.ToString();
    }
}
