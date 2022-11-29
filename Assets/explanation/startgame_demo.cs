using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace CoEmbodimentSystem
{
    public class startgame_demo : MonoBehaviour
    {
        [SerializeField] private GameObject countdown;
        [SerializeField] timelimit_demo _timeLimit;
        private bool up_start = false;
        private bool downready = true;
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
                downcount = 0;
                countdown.GetComponent<Text>().color = new Color(0, 0, 0);
                countdown.GetComponent<RectTransform>().localScale = initialScale;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "hitstick_demo")
            {
                up_start = true;
                if (Judgment_demo.ToString() == "START")
                {
                    _timeLimit.demostart = true;
                }
                else
                {
                    _timeLimit.demostart = false;
                }
            }

        }
    }
}