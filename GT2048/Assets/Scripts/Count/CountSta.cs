using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountSta: MonoBehaviour {
    public GameObject Count;
    public void OnAwake()
    {
        Debug.Log("fuck");
        Count.SetActive(true);
    }
    public void OnCancle()
    {
        Count.SetActive(false);
    }
}
