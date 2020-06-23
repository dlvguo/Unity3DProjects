using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManger : MonoBehaviour {
    public static bool gameover=false;
    public static int number;
    public GameObject face;
	// Use this for initialization
	void Start () {
        Invoke("creat", 0.1f);
        number = Grid.height * Grid.weight - Grid.boomnum;
	}
	
	// Update is called once per frame
	void Update () {
        if (number == 0)
            face.GetComponent<Image>().sprite = face.GetComponent<text>().num[2];
        if (gameover)
            face.GetComponent<Image>().sprite = face.GetComponent<text>().num[1];
        if (Input.GetMouseButtonDown(1))
        {
            int x = ((int)Input.mousePosition.x-252)/16,y= ((int)Input.mousePosition.y-38)/16 ;
            Grid.element[x, y].image.sprite = Grid.element[x, y].num[12];
        }

    }
    public void creat()
    {
        Grid.creatboom();
    }
    public static void restart()
    {
        gameover = false;
        number = Grid.height * Grid.weight - Grid.boomnum ;
        for (int i=0;i<Grid.height;i++)
            for (int j=0;j<Grid.weight;j++)
            {
                Grid.element[i, j].restart();
                Grid.visit[i, j] = 0;
            }
        Grid.creatboom();
    }
}
