using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    Vector2 start, end;
    Vector3[] trailPos = new Vector3[10];
    Color sC, eC;
    public LineRenderer trail;
    int posIndex;
    float trail_alpha = 0.63f;
    int raycastCount = 10;
    // Use this for initialization
    void Start()
    {
        trail_alpha = 1f;
        sC = trail.startColor;
        eC = trail.endColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            start = end = Input.mousePosition;
            posIndex = 0;
            StartCoroutine("Control");
        }
        
    }
    public IEnumerator Control()
    {
        trail_alpha = 1f;
        trail.startColor = new Color(sC.r, sC.g, sC.b, trail_alpha);
        trail.endColor = new Color(eC.r, eC.g, eC.b, trail_alpha);
        while (Input.GetMouseButton(0))
        {            
            end = Input.mousePosition;
            var a = new Vector3(start.x, start.y, 8);
            var b = new Vector3(end.x, end.y, 8);
            if (Vector3.Distance(a, b) > 0.1f)
            {
                AddPos();
            }
            start = end;
            if (trail_alpha > 0.5f)
            {
                for (var p = 0; p < 8; p++)
                {
                    Vector3 s = Camera.main.WorldToScreenPoint(trailPos[p]);
                    Vector3 e = Camera.main.WorldToScreenPoint(trailPos[p]);
                    for (var i = 0; i < raycastCount; i++)
                    {
                        Ray ray = Camera.main.ScreenPointToRay(Vector3.Lerp(s, e, 1f * i / raycastCount));
                        RaycastHit hit;
                        if (Physics.Raycast(ray, out hit, 100))
                        {
                            HitTest(hit);
                        }
                    }
                }
            }            
            SendTrailPos();            
            yield return new WaitForFixedUpdate();
        }
        trail.startColor = new Color(sC.r, sC.g, sC.b, 0f);
        trail.endColor = new Color(eC.r, eC.g, eC.b, 0f);
    }
    void HitTest(RaycastHit hit)
    {
        if (hit.collider.tag=="fruits")
        {
            
            hit.collider.gameObject.GetComponent<beKill>().OnKill();
            hit.collider.gameObject.GetComponent<beKill>().isKilled = true;
            Destroy(hit.collider.gameObject);

        }
    } 
    void AddPos()
    {
        if (posIndex < 10)
            for (var i = posIndex; i < 10; i++)
            {
                trailPos[i] = Camera.main.ScreenToWorldPoint(new Vector3(end.x, end.y, 7));
               
            }
        else
        {
            for (var i = 0; i < 9; i++)
                trailPos[i] = trailPos[i + 1];
            trailPos[9] = Camera.main.ScreenToWorldPoint(new Vector3(end.x, end.y, 7));
        }
        posIndex++;
    }
    void SendTrailPos()
    {        
        trail.SetPositions(trailPos);
    }
}
