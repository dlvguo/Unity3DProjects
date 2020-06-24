using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum enemy
{
    smallplane,
    midlleplane,
    bigplane
}
public class Enemy : MonoBehaviour
{
    public int hp;
    public int framePersconds = 1;
    public int score;

    public enemy type;
    public bool isdead = false;

    public Sprite[] deadplane;
    public Sprite[] hitplane;

    public float timer = 0;
    public  float speed ;
    public float hittime = 0;
    // Use this for initialization
        void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-transform.up * (speed+Mangage.speed) * Time.deltaTime);
        if (transform.position.y < -5.32f)
            Destroy(gameObject);
        if (isdead)
        {
            timer += Time.deltaTime;
            int frame = (int)(timer / (1f / framePersconds));
            if (frame > 3)
                Destroy(gameObject);
            else
                gameObject.GetComponent<SpriteRenderer>().sprite = deadplane[frame];
        }
        else
        {
            if (hittime > 0)
            {
                hittime -= Time.deltaTime;
                gameObject.GetComponent<SpriteRenderer>().sprite = hitplane[((int)(hittime * 10)) % 2];
            }
            if (hittime <= 0 && type != enemy.smallplane)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = hitplane[0];
                hittime = 0f;
            }
        }
    }
    
    void BeHit()
    {   if (hittime == 0)
        {
            hp--;
            hittime = Mangage.hittime;
        }

        if (hp < 1)
        {
            isdead = true;
            Mangage.score += score;
            if (Mangage.score / 1500 > Mangage.level - 1&&Mangage.level<5)
            {
                Mangage.level++;
                Mangage.hittime += 0.1f;
                Mangage.speed += 0.1f;
            }
            if (Mangage.score / 2200 > Mangage.level - 1&&Mangage.level>=5)
            {
                Mangage.speed += 0.2f;
                Mangage.level++;
                Mangage.hittime += 0.1f;
            }
        }

    }
}
