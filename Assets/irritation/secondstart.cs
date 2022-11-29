using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class secondstart : MonoBehaviour
{



    private bool up_start = false;
    private float downcount = 0;
    private float changetime = 0.3f;
    private bool _goal = false;
    //[SerializeField] mingturn Mingturn;
    //GameObject Panel;
    private bool starting_game = false;
    private Vector3 initialScale;


    // Start is called before the first frame update
    void OnEnable()
    {
        initialScale = this.GetComponent<RectTransform>().localScale;
        countdown3();
        Invoke("countdown2", 1.0f);
        Invoke("countdown1", 2.0f);
        Invoke("startinggame", 3.0f);
    }


    // Update is called once per frame
    void Update()
    {
        if (up_start && downcount < changetime)
        {
            this.GetComponent<Text>().color += new Color(255 * Time.deltaTime / changetime, 0, 0);
            this.GetComponent<RectTransform>().localScale += new Vector3(0.000001f, 0.000001f, 0);
            downcount += Time.deltaTime;
        }
        else if (downcount >= changetime && downcount < changetime * 2)
        {
            this.GetComponent<Text>().color = new Color(255 * (1 - Time.deltaTime / changetime), 0, 0);
            this.GetComponent<RectTransform>().localScale -= new Vector3(0.000001f, 0.000001f, 0);
            downcount += Time.deltaTime;
        }
        else
        {
            up_start = false;
            downcount = 0;
            this.GetComponent<Text>().color = new Color(0, 0, 0);
            this.GetComponent<RectTransform>().localScale = initialScale;
        }
    }
    void startinggame()
    {
        this.GetComponent<Text>().text = "START";
        up_start = true;
    }
    void countdown1()
    {
        up_start = true;
        this.GetComponent<Text>().text = "1";
    }
    void countdown2()
    {
        up_start = true;
        this.GetComponent<Text>().text = "2";
    }
    void countdown3()
    {
        up_start = true;
        this.GetComponent<Text>().text = "3";
    }    
}
