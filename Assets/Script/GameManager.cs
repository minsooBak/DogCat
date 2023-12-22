using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    public GameObject dog;
    public GameObject food;
    public GameObject normalCat;
    public GameObject fatCat;
    public GameObject pirateCat;
    public GameObject retrytBtn;
    public Text levelText;
    public GameObject levelFront;

    int level = 0;
    int cat = 0;

    private void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        InvokeRepeating("MakeFood", 0.0f, 0.1f);
        InvokeRepeating("MakeCat", 0.0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeFood()
    {
        float x = dog.transform.position.x;
        float y = dog.transform.position.y + 2.0f;

        Instantiate(food, new Vector3(x, y, 0), Quaternion.identity);
    }
    void MakeCat()
    {
        Instantiate(normalCat);

        if (level == 1)
        {
            float p = Random.Range(0, 10);
            if (p < 2) Instantiate(normalCat);
        }
        else if (level == 2)
        {
            float p = Random.Range(0, 10);
            if (p < 5) Instantiate(normalCat);
        }else if(level == 3)
        {
            float p = Random.Range(0, 10);
            if (p < 6) Instantiate(normalCat);
            Instantiate(fatCat);
        }else if (level >= 4)
        {
            float p = Random.Range(0, 10);
            if (p < 8) Instantiate(normalCat);
            if(p < 4) Instantiate(fatCat);
            Instantiate(fatCat);
            Instantiate(pirateCat);
        }

    }
    public void GameOver()
    {
        retrytBtn.SetActive(true);
        Time.timeScale = 0;
    }

    public void addCat()
    {
        cat += 1;
        level = cat / 5;

        levelText.text = level.ToString();
        levelFront.transform.localScale = new Vector3((cat - level * 5) / 5.0f, 1f, 1f);
    }

}
