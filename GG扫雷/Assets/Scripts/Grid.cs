using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid  {
    public static int height = 16, weight = 16;
    public int count=0;
    public int x, y;
    public static int [,] dis = {{ 0,1},{ 0,-1}, { 1, 0 }, { -1,0}, { 1,1}, { -1,-1}, { 1,-1}, { -1,1} };
    public static int boomnum = 15;
    public static int[,] visit = new int[height, weight];

    public static Element[,] element = new Element[height, weight];
    public bool isboom=false;
    public bool isclick=true;
    public static void dfs(int x,int y)
    {
       
      int x1, y1;
      for (int i = 0; i < 8; i++)
        {
            x1 = x + dis[i, 0];
            y1 = y + dis[i, 1];
            if (x1 < 0 || x1 >= height || y1 < 0 || y1 >= weight)
                continue;
            if (element[x1, y1].grid.isboom)
                element[x, y].grid.count++;
        }
        element[x, y].image.sprite = element[x, y].num[element[x, y].grid.count];
        if (element[x,y].grid.count==0)
            for (int i = 0; i < 8; i++)
            {
                x1 = x + dis[i, 0];
                y1 = y + dis[i, 1];
                if (x1 < 0 || x1 >= height || y1 < 0 || y1 >= weight||visit[x1,y1]==1)
                    continue;
                visit[x1, y1] = 1;
                GameManger.number--;
                element[x1, y1].button.enabled = false;
                dfs(x1, y1);
            }
    }
    public static void creatboom()
    {
        int x1, y1;
        for (int i = 0; i < boomnum; i++)
        {
            x1 = Random.Range(0, 15);
            y1 = Random.Range(0, 15);
            if (element[x1, y1].grid.isboom)
            {
                i--;
                continue;
            }
            element[x1, y1].grid.isboom = true;
        }
    }
}
