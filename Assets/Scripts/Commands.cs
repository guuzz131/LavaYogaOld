using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Commands : MonoBehaviour
{
    public float timer = 4f;
    public Text Lives;
    public int i;
    public bool correct;
    public int points;
    public Controller controller;
    public GameObject deathScreen;

    public GameObject UpOutline;
    public GameObject DownOutline;
    public GameObject RightOutline;
    public GameObject LeftOutline;

    public GameObject WallTop;
    public GameObject WallLeft;
    public GameObject WallRight;
    public GameObject WallLeftRight;

    bool playAni;

    void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 1.2f && playAni == false)
            {
                if (i == 1) PlayWalls(WallTop);
                if (i == 0) PlayWalls(WallLeftRight);
                if (i == 2) PlayWalls(WallLeft);
                playAni = true;
            }
            if (timer <= .8f)
            {
                controller.CheckPosition(i);
            }
        }
        else
        {
            UpOrDown();
            timer = 4f;
            playAni = false;
        }
    }
    IEnumerator Reset(GameObject gameObject)
    {
        yield return new WaitForSeconds(2.2f);
        gameObject.SetActive(false);
    }

    private void PlayWalls(GameObject Wall)
    {
        Wall.SetActive(true);
        StartCoroutine(Reset(Wall));
        Wall.GetComponent<Animation>().Stop();
        Wall.GetComponent<Animation>().Play();
        if (i == 0)
        {
            UpOutline.SetActive(true);
        }
        else if (i == 1)
        {
            DownOutline.SetActive(true);
        }
        else if (i == 2)
        {
            RightOutline.SetActive(true);
        }
    }

    private void UpOrDown()
    {
        if (correct)
        {
            points += 1;
            Lives.text = points.ToString();
        }
        else
        {
            deathScreen.SetActive(true);
            Time.timeScale = 0;
        }
        correct = false;
        i = Random.Range(0, 3);
        if (i == 0)
        {
            UpOutline.SetActive(false);
            DownOutline.SetActive(false);
            RightOutline.SetActive(false);
        }
        else if (i == 1)
        {
            UpOutline.SetActive(false);
            DownOutline.SetActive(false);
            RightOutline.SetActive(false);
        }
        else if (i == 2)
        {
            UpOutline.SetActive(false);
            DownOutline.SetActive(false);
            RightOutline.SetActive(false);
        }
    }
}
