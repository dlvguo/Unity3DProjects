using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour {
    public Image image;
    public Sprite[] num;
	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onclick()
    {
        image.sprite = num[0];
        GameManger.restart();
    }
}
