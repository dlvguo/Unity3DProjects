using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankManger : MonoBehaviour {
    public GameObject item;

    private void Start()
    {
        SetRank();
    }
    private void SetRank()
    {
        int i = 0;
        List<RankList> rankList = LoadRankList();
        foreach (var _item in rankList)
        {
           var go= Instantiate(item, transform) as GameObject;
            RankList rank = go.GetComponent<RankList>();            
            rank.SetShow(_item.rankNum, _item.score, _item.data);            
            RectTransform rect = go.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector3(-150, 120-i*80, 0);
            i++;
        }
    }
	private List<RankList> LoadRankList()
    {
        List<RankList> rankList = new List<RankList>();
        RankList item1 = new RankList();
        item1.score = 9999;
        item1.data = "2017-11-06";
        item1.rankNum = 1;
        rankList.Add(item1);
        RankList item2 = new RankList();
        item2.score = 999;
        item2.data = "2017-11-06";
        item2.rankNum = 2;
        rankList.Add(item2);
        RankList item3 = new RankList();
        item3.score = 999;
        item3.data = "2017-11-06";
        item3.rankNum = 3;
        rankList.Add(item3);
        RankList item4 = new RankList();
        item4.score = 99;
        item4.data = "2017-11-06";
        item4.rankNum = 4;
        rankList.Add(item4);
        RankList item5 = new RankList();
        item5.score = 9;
        item5.data = "2017-11-06";
        item5.rankNum = 5;
        rankList.Add(item5);
        Debug.Log(rankList.Count);
        return rankList;
    }

}
