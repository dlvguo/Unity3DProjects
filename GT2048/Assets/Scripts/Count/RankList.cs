using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankList : MonoBehaviour {
    public int rankNum=0;
    public int score = 0;
    public string data = "2017-11-06";
    public Text _rankNum;
    public Text _score;
    public Text _data;
    

    public void SetShow(int ranNum,int score,string data)
    {
        _rankNum.text = "No." + ranNum.ToString();
        _score.text = score.ToString();
        _data.text = data;
    }

}
