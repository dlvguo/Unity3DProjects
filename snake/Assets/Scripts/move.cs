using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class move : MonoBehaviour
{
    public int division;
    public GameObject body;
    public Button restart;
    // Use this for initialization
    void Start()
    {
        gamemanger.Q.Add(transform.position);
        division = 1;
        InvokeRepeating("console", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -36f || transform.position.x > 36f)
            transform.position = transform.position.x > 0 ? new Vector3(-36f, transform.position.y, 0) : new Vector3(36f, transform.position.y, 0);
        if (transform.position.y < -18f || transform.position.y > 18f)
            transform.position = transform.position.y > 0 ? new Vector3(transform.position.x,-18f, 0) : new Vector3(transform.position.x, 18f, 0);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            division = 1;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            division = 2;
        if (Input.GetKeyDown(KeyCode.UpArrow))
            division = 3;
        if (Input.GetKeyDown(KeyCode.DownArrow))
            division = 4;

    }
    void console()
    {
        gamemanger.Q[0] = transform.position;
        switch (division)
        {
            case 1: transform.Translate(new Vector3(-2.5f, 0, 0)); break;
            case 2: transform.Translate(new Vector3(2.5f, 0, 0)); break;
            case 3: transform.Translate(new Vector3(0, 2.5f, 0)); break;
            case 4: transform.Translate(new Vector3(0, -2.5f, 0)); break;
            default:
                break;
        }

    }
    void OnTriggerEnter2D(Collider2D a)
    {
        if (a.gameObject.tag == "body")
        {
            Time.timeScale = 0;
            restart.gameObject.SetActive(true);
        }
        else
        {
            gamemanger.bodynum++;
            Destroy(a.gameObject);
            Instantiate(body, gamemanger.Q[gamemanger.bodynum - 1], Quaternion.identity);
        }
    }
}
