using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Element : MonoBehaviour {
    private int x;
    private int y;
    private int value=0;
    private int id = 0;
    public Sprite[] sprites;
    private Image image;
    private void Start()
    {
        image = gameObject.GetComponent<Image>();
        RectTransform rect = transform as RectTransform;
        myid = 0;
        myvalue = 0;
        x = (int)(rect.anchoredPosition.x + 150) / 100;
        y = (int)(rect.anchoredPosition.y + 150) / 100;
        ElementManger.elementManger.element[x, y] = this;
        transform.gameObject.SetActive(false);
    }
    public int myid
    {
        set {
            id = value;
         }
        get
        {
            return id;
        }
    }
    public int myvalue
    {
        set
        {
            this.value = value;
        }
        get
        {
            return this.value;
        }
    }
    public void SetSprite()
    {
        this.image.sprite = sprites[id-1];
    }
}
