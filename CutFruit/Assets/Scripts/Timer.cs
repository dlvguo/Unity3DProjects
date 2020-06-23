using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public Text timer;
    public Text scorer;
    private float _t1, _t2, _t3;
    public int score;
	// Use this for initialization
	void Start () {
        score = 0;
        _t1 = _t2 = _t3 = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timer.text ="Time:"+ ((int)Time.time).ToString();
	}
}
