using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero : MonoBehaviour
{
    public bool animatin = true;
    public int frameCountPersconds = 10;
    public float timer = 0;
    public Sprite[] sprites;
    private bool isMouseDown = false;
    public Vector3 LastMouseposition = Vector3.zero;
    public float superGunTime = 10f;
    public GameObject top, left, right,boom;
    public float runtime;
    public float boomtime;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (animatin)
        {
            timer += Time.deltaTime;
            int fram = (int)(timer * 10) % 2;
            SpriteRenderer a = GetComponent<SpriteRenderer>();
            a.sprite = sprites[fram];
        }
        if (Input.GetMouseButtonDown(0))
            isMouseDown = true;
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
            LastMouseposition = Vector3.zero;
        }
        if (isMouseDown)
        {
            if (LastMouseposition != Vector3.zero)
            {
                Vector3 translate = Camera.main.ScreenToWorldPoint(Input.mousePosition) - LastMouseposition;
                transform.position += translate;
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.77f, 1.89f), Mathf.Clamp(transform.position.y, -3.18f, 3.29f), 0);
            }
            LastMouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (runtime > 0)
        {
            runtime -= Time.deltaTime;
            if (runtime <= 0)
            {
                OverGun();
                runtime = 0;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Award" && collision.gameObject.GetComponent<Award>().type == 0)
        {
            runtime = 10f;
            SuperGun();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Award" && collision.gameObject.GetComponent<Award>().type == 1)
        {
            Destroy(collision.gameObject);
            Mangage.numbobmb++;
        }
    }
    void SuperGun()
    {
        left.SetActive(true);
        left.GetComponent<Gun>().openfire();
        right.SetActive(true);
        right.GetComponent<Gun>().openfire();
    }
    void OverGun()
    {
        left.SetActive(false);
        left.GetComponent<Gun>().CancelInvoke();
        right.SetActive(false);
        right.GetComponent<Gun>().CancelInvoke();
    }
}
