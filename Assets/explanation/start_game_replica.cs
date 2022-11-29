using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CoEmbodimentSystem
{
    public class start_game_replica : MonoBehaviour
    {
        [SerializeField] private GameObject countdown;
        [SerializeField] timelimit_demo _timeLimit;
        private bool up_start = false;
        public bool downready = true;
        private float downcount = 0;
        private float changetime = 0.3f;
        private Vector3 initialScale;
        public enum judgment
        {
            START, GOAL,
        }
        public judgment Judgment_demo;
        // Start is called before the first frame update
        void Start()
        {
            initialScale = countdown.GetComponent<RectTransform>().localScale;

        }

        // Update is called once per frame
        void Update()
        {
            if (up_start && downcount < changetime)
            {
                countdown.GetComponent<Text>().color += new Color(255 * Time.deltaTime / changetime, 0, 0);
                countdown.GetComponent<RectTransform>().localScale += new Vector3(0.005f, 0.005f, 0);
                downcount += Time.deltaTime;
            }
            else if (downcount >= changetime && downcount < changetime * 2)
            {
                countdown.GetComponent<Text>().color = new Color(255 * (1 - Time.deltaTime / changetime), 0, 0);
                countdown.GetComponent<RectTransform>().localScale -= new Vector3(0.005f, 0.005f, 0);
                downcount += Time.deltaTime;
            }
            else
            {
                up_start = false;
                countdown.GetComponent<Text>().color = new Color(0, 0, 0);
                countdown.GetComponent<RectTransform>().localScale = initialScale;
                downcount = 0;
            }
        }

        void startinggame()
        {
            _timeLimit.demostart = true;
            countdown.GetComponent<Text>().text = "START";
            up_start = true;
        }
        void countdown1()
        {
            up_start = true;
            countdown.GetComponent<Text>().text = "1";
        }
        void countdown2()
        {
            up_start = true;
            countdown.GetComponent<Text>().text = "2";
        }
        void countdown3()
        {
            up_start = true;
            countdown.GetComponent<Text>().text = "3";
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "hitstick_demo_opponent")
            {
                if (Judgment_demo.ToString() == "START" && downready)
                {
                    downready = false;
                    countdown3();
                    Invoke("countdown2", 1.0f);
                    Invoke("countdown1", 2.0f);
                    Invoke("startinggame", 3.0f);
                }

            }
            if (other.name == "hitstick_demo" && Judgment_demo.ToString() == "GOAL")
            {

                _timeLimit.demostart = false;
                up_start = true;

            }

        }
    }
}