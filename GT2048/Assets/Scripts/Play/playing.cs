using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playing : MonoBehaviour
{
    public static playing play;
    // Use this for initialization
    void Start()
    {
        play = this;
        Invoke("ReStrat", 0.1f);        
    }
    public void ReStrat()
    {
        ElementManger.elementManger.score = 0;
        ElementManger.elementManger.elementNum = 0;
        SrankEle();
        SrankEle();
        ScoreMan.scoreMan.SetHigh();
        ScoreMan.scoreMan.score = 0;
        ScoreMan.scoreMan.SetScore(0);        
    }
    private void ReElement()
    {
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
                ElementManger.elementManger.element[i, j].myid = ElementManger.elementManger.element[i, j].myvalue= 0;
    }
    private void SetElement(int lie, int row, int k, bool isRight)
    {
        if (isRight)
        {
            ElementManger.elementManger.element[k, row].myvalue = ElementManger.elementManger.element[lie, row].myvalue;
            ElementManger.elementManger.element[k, row].myid = ElementManger.elementManger.element[lie, row].myid;
            ElementManger.elementManger.element[k, row].transform.gameObject.SetActive(true);
            ElementManger.elementManger.element[k, row].SetSprite();
            ElementManger.elementManger.element[lie, row].myvalue = 0;
            ElementManger.elementManger.element[lie, row].myid = 0;
            ElementManger.elementManger.element[lie, row].transform.gameObject.SetActive(false);
        }
        else
        {
            ElementManger.elementManger.element[row, k].myvalue = ElementManger.elementManger.element[row, lie].myvalue;
            ElementManger.elementManger.element[row, k].myid = ElementManger.elementManger.element[row, lie].myid;
            ElementManger.elementManger.element[row, k].transform.gameObject.SetActive(true);
            ElementManger.elementManger.element[row, k].SetSprite();
            ElementManger.elementManger.element[row, lie].myvalue = 0;
            ElementManger.elementManger.element[row, lie].myid = 0;
            ElementManger.elementManger.element[row, lie].transform.gameObject.SetActive(false);
        }
    }    
    public void Right()
    {
        int k, j;
        for (int row = 0; row < 4; row++)
        {
            k = 3;
            for (int lie = 3; lie >= 0; lie--)
            {
                if (ElementManger.elementManger.element[lie, row].myid != 0)
                {
                    for (j = lie - 1; j >= 0; j--)
                        if (ElementManger.elementManger.element[j, row].myid != 0)
                            break;
                    if (j == -1)
                    {
                        if (lie != k)
                        {
                            SetElement(lie, row, k,true);
                            k--;
                        }
                    }
                    else if (ElementManger.elementManger.element[j, row].myid == ElementManger.elementManger.element[lie, row].myid)
                    {
                        Removed(row, lie, j,false);
                        if (lie != k)
                            SetElement(lie, row, k,true);
                        k--;
                        lie = k + 1;
                    }
                    else
                    {
                        if (lie != k)
                            SetElement(lie, row, k,true);
                        k--;
                        lie = j + 1;
                    }
                }
            }
        }        
        SrankEle();
    }
    public void Left()
    {
        int k, j;
        for (int row = 0; row < 4; row++)
        {
            k = 0;
            for (int lie = 0; lie < 4; lie++)
            {
                if (ElementManger.elementManger.element[lie, row].myid != 0)
                {                    
                    for (j = lie + 1; j < 4; j++)
                        if (ElementManger.elementManger.element[j, row].myid != 0)
                            break;
                    if (j == 4)
                    {
                        if (lie != k)
                        {
                            SetElement(lie, row, k,true);
                            k++;
                        }
                    }
                    else if (ElementManger.elementManger.element[j, row].myid == ElementManger.elementManger.element[lie, row].myid)
                    {
                        Removed(row, lie, j,false);
                        if (lie != k)
                            SetElement(lie, row, k,true);
                        k++;
                        lie = k - 1;
                    }
                    else
                    {
                        if (lie != k)
                            SetElement(lie, row, k,true);
                        k++;
                        lie = j - 1;
                    }
                }
            }
        }
        SrankEle();
    }
    public void Up()
    {
        int k, j;
        for (int row = 0; row < 4; row++)
        {
            k = 3;
            for (int lie = 3; lie >= 0; lie--)
            {
                if (ElementManger.elementManger.element[row, lie].myid != 0)
                {
                    for (j = lie - 1; j >= 0; j--)
                        if (ElementManger.elementManger.element[row, j].myid != 0)
                            break;
                    if (j == -1)
                    {
                        if (lie != k)
                        {
                            SetElement(lie, row, k,false);
                            k--;
                        }
                    }
                    else if (ElementManger.elementManger.element[row,j].myid == ElementManger.elementManger.element[row,lie].myid)
                    {
                        Removed(row, lie, j,true);
                        if (lie != k)
                            SetElement(lie, row, k,false);
                        k--;
                        lie = k + 1;
                    }
                    else
                    {
                        if (lie != k)
                            SetElement(lie, row, k,false);
                        k--;
                        lie = j + 1;
                    }
                }
            }
        }
        SrankEle();
    }
    public void Down()
    {
        int k, j;
        for (int row = 0; row < 4; row++)
        {
            k = 0;
            for (int lie = 0; lie <4 ; lie++)
            {
                if (ElementManger.elementManger.element[row, lie].myid != 0)
                {
                    for (j = lie + 1; j <4; j++)
                        if (ElementManger.elementManger.element[row, j].myid != 0)
                            break;
                    if (j == 4)
                    {
                        if (lie != k)
                        {
                            SetElement(lie, row, k,false);
                            k++;
                        }
                    }
                    else if (ElementManger.elementManger.element[row, j].myid == ElementManger.elementManger.element[row, lie].myid)
                    {
                        Removed(row, lie, j,true);
                        if (lie != k)
                            SetElement(lie, row, k,false);
                        k++;
                        lie = k - 1;
                    }
                    else
                    {
                        if (lie != k)
                            SetElement(lie, row, k, false);
                        k++;
                        lie = j - 1;
                    }
                }
            }
        }
        SrankEle();
    }
    private bool Check()
    {
        for (int i = 0; i < 4; i++)        
            for (int j = 0; j < 3; j++)            
                if (ElementManger.elementManger.element[i, j].myid == ElementManger.elementManger.element[i, j + 1].myid)
                    return true;
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 3; j++)
                if (ElementManger.elementManger.element[j, i].myid == ElementManger.elementManger.element[j+1, i].myid)
                    return true;
        return false;
    }
    private void SrankEle()
    {
        if (ElementManger.elementManger.elementNum < 16)
         while (true)
        {
            int x1 = Random.Range(0, 4);
            int y1 = Random.Range(0, 4);
            if (ElementManger.elementManger.element[x1, y1].myid == 0)
            {
                ElementManger.elementManger.element[x1, y1].myid = 1;
                ElementManger.elementManger.element[x1, y1].myvalue = 2;
                ElementManger.elementManger.element[x1, y1].SetSprite();
                ElementManger.elementManger.element[x1, y1].transform.gameObject.SetActive(true);
                ElementManger.elementManger.elementNum ++;
                    if (ElementManger.elementManger.elementNum == 16)
                        if (!Check())
                            Debug.Log("fcfcfc");
                break;
            }
        }
    }
    private void Removed(int row,int lie ,int j,bool isUp)
    {
        if (isUp)
        {
            ElementManger.elementManger.element[row, lie].myvalue *= 2;
            SetScore(ElementManger.elementManger.element[row, lie].myvalue/2);
            ElementManger.elementManger.element[row, lie].myid++;
            ElementManger.elementManger.element[row, lie].SetSprite();
            ElementManger.elementManger.element[row, j].myid = 0;
            ElementManger.elementManger.element[row, j].myvalue = 0;
            ElementManger.elementManger.element[row, j].transform.gameObject.SetActive(false);
        }
        else
        {
            ElementManger.elementManger.element[lie, row].myvalue *= 2;
            SetScore(ElementManger.elementManger.element[lie, row].myvalue/2);
            ElementManger.elementManger.element[lie, row].myid++;
            ElementManger.elementManger.element[lie, row].SetSprite();
            ElementManger.elementManger.element[j, row].myid = 0;
            ElementManger.elementManger.element[j, row].myvalue = 0;
            ElementManger.elementManger.element[j, row].transform.gameObject.SetActive(false);
        }
        ElementManger.elementManger.elementNum--;
    }
    private void SetScore(int score)
    {
        ScoreMan.scoreMan.SetScore(score);
    }
}
