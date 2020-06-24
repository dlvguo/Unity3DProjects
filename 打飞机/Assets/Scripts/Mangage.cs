using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mangage : MonoBehaviour {
    public static int score=0;
    public static int level = 1;
    public static int numbobmb = 0;
    public Text a;
    public float timer = 0;
    public static float speed;
    public static float hittime = 0.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        a.text = "          Level:" + level.ToString()+ "      Score:" + score.ToString()+"      Time:"+ ((int)timer).ToString();
	}
}
