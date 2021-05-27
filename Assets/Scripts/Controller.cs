using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.IO.Ports;

public class Controller : MonoBehaviour
{
    SerialPort dataStream;
    public string receivedString;
    public GameObject testText;
    
    public float timer = .2f;
    public Commands commands;
    public int livesTotal = 3;
    public int lives;

    public SpriteRenderer Poses;
    public Sprite Tall;
    public Sprite Short;
    public Sprite TallRight;
    public Sprite TallLeft;

    public float height;
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        dataStream = new SerialPort("COM3", 9600);
        dataStream.Open();
        lives = livesTotal;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            getNumbers();
            timer = .2f;
            if (commands.i == 0)
            {
                if (height >= 50)
                {
                    //testText.GetComponent<Text>().text = "Good";
                }
                else
                {
                    //testText.GetComponent<Text>().text = "Heigher Bitch";
                }
            }
            else
            {
                if (height >= 50)
                {
                    //testText.GetComponent<Text>().text = "Lower Hoe";
                }
                else
                {
                    //testText.GetComponent<Text>().text = "Good";
                }
            }
        }
    }
    private void getNumbers()
    {
        dataStream.ToString();

        receivedString = dataStream.ReadLine();
        string[] data = receivedString.Split(',');
        angle = GetFloat(data[1], 0);
        height = GetFloat(data[0], 0);
        if (height > 100 && angle == 1)
        {
            Poses.sprite = Tall;
            //testText.GetComponent<Text>().text = "Tall";
        }
        else if (height > 100 && angle == 0)
        {
            Poses.sprite = TallRight;
        }
        else
        {
            Poses.sprite = Short;
            //testText.GetComponent<Text>().text = "Short";
        }
    }
    private float GetFloat(string stringValue, float defaultValue)
    {
        float result = defaultValue;
        float.TryParse(stringValue, out result);
        return result;
    }
    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

    public void CheckPosition(int i)
    {
        if (i == 0)
        {
            if (height > 100 && angle == 1)
            {
                commands.correct = true;
            }
            
        }
        else if (i == 1)
        {
            if (height < 100)
            {
                commands.correct = true;
            }
            
        } else if (i == 2)
        {
            if (height > 100 && angle == 0)
            {
                commands.correct = true;
            }
        }
    }
}
