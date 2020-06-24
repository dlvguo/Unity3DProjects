using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Click : MonoBehaviour {
    public GameObject boom;
    public float runtime=0;
    public Text a;
	// Use this for initialization
	void OnMouseUp()
    {   if (Mangage.numbobmb > 0)
        {
            runtime = 0.5f;
            boom.gameObject.SetActive(true);
            Mangage.numbobmb--;
        }
    }
    void Update()
    {
        a.text = "X " + Mangage.numbobmb.ToString();
        if (runtime > 0)
        {
            runtime -= Time.deltaTime;
            if (runtime <= 0f)
            {
                boom.gameObject.SetActive(false);
                runtime = 0;
            }
        }
    }
}
