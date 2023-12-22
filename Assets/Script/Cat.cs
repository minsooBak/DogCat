using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    float full = 5f;
    float energy = 0.0f;
    bool isFull = false;
    public int type;
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-8.5f, 8.5f);
        float y = 30.0f;
        transform.position = new Vector3(x, y, 0);

        if (type == 1)
            full = 10f;
        else if (type == 2)
            full = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        if (energy < full)
        {
            if (type == 0)
                transform.position += new Vector3(0.0f, -3.5f * Time.deltaTime, 0.0f);
            else if(type == 1)
                transform.position += new Vector3(0.0f, -1.5f * Time.deltaTime, 0.0f);
            else
                transform.position += new Vector3(0.0f, -3.5f * Time.deltaTime, 0.0f);
            if (transform.position.y < -16f)
            {
                GameManager.I.GameOver();
            }
        }
        else
        {
            if (transform.position.x > 0)
                transform.position += new Vector3(0.5f * Time.deltaTime, 0, 0);
            else
                transform.position += new Vector3(-0.5f * Time.deltaTime, 0, 0);
            Destroy(gameObject, 3f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "food")
        {
            if (energy < full)
            {
                energy += 30.0f * Time.deltaTime;
                gameObject.transform.Find("Hungry/Canvas/Front").transform.localScale = new Vector3(energy / full, 1, 1);
                Destroy(collision.gameObject);
            }
            else
            {
                if (isFull == false)
                {
                    GameManager.I.addCat();
                    gameObject.transform.Find("Hungry").gameObject.SetActive(false);
                    gameObject.transform.Find("Full").gameObject.SetActive(true);
                    isFull = true;
                }
            }
        }
    }
}
