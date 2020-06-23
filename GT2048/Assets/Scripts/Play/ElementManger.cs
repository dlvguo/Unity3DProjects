using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementManger : MonoBehaviour {
    public static ElementManger elementManger;
    public int score = 0;
    public int highScore = 0;
    public Element[,] element =new Element[4,4];
    public int elementNum=0;
    private void Awake()
    {
        elementManger = this;
    }    	
	
	void Update () {        
        if (Input.GetMouseButtonDown(0))
            StartCoroutine(mousePos(Input.mousePosition));    
	}
    
    private IEnumerator mousePos(Vector2 mouPos)
    {        
        Vector2 mouseLeft = Vector2.zero;
        while (Input.GetMouseButton(0))
        {
            mouseLeft = Input.mousePosition;
            yield return new WaitForFixedUpdate();
        }
        float x= mouseLeft.x-mouPos.x;
        float y=mouseLeft.y-mouPos.y;
        if (x > 30f)
            playing.play.Right();
        if (x < -30f)
            playing.play.Left();
        if (y > 30f)
            playing.play.Up();
        if (y<-30f)
            playing.play.Down();
    }
}
