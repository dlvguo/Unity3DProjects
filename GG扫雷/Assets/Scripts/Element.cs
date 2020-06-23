using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Element : MonoBehaviour
{
    public Image image;
    public Sprite[] num;
    public Grid grid=new Grid();
    public Button button;
    // Use this for initialization
    void Start () {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        grid.x = (int)(transform.position.x / 20);
        grid.y = (int)transform.position.y / 20;
        Grid.element[grid.x, grid.y] = this;
        Grid.visit[grid.x, grid.y] = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void onprintf()
    {
        if (grid.isboom)
        {
            image.sprite = num[9];
            grid.isboom = false;
            for (int i = 0; i < Grid.height; i++)
                for (int j = 0; j < Grid.weight; j++)
                    if (Grid.element[i, j].grid.isboom)
                        Grid.element[i, j].image.sprite = num[10];
            GameManger.gameover = true;
        
        }
        else
        {
            Grid.dfs(grid.x, grid.y);
            Grid.visit[grid.x, grid.y] = 1;
            GameManger.number--;
           
        }
            button.enabled = false;
        
    }
    public void restart()
    {
        image.sprite = num[11];
        button.enabled = true;
        grid.isboom = false;
        grid.count = 0;
    }
}
