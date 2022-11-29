using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace CoEmbodimentSystem
{
    public class movestick_replica : MonoBehaviour
    {
        [SerializeField] GameObject goal1;
        [SerializeField] GameObject goal2;
        [SerializeField] GameObject goal3;
        Vector3 start_pos;
        [SerializeField] fadestick_demo _FadeStick_Demo;
        [SerializeField] timelimit_demo _Demo_Start;
        [SerializeField] GameObject _you;
        explanation_system Explanation_System;
        private bool moving = false;
        private bool once = true;
        private bool waitforstart = false;
        private bool move_start = false;
        private int i = 0;
        [SerializeField] GameObject replica;
        Vector3 replica_pos;
        // Start is called before the first frame update
        void Start()
        {
            Explanation_System = GameObject.Find("Explanation/ExplanationManager").gameObject.GetComponent<explanation_system>();
            replica_pos = replica.transform.position;

        }

        // Update is called once per frame
        void Update()
        {
            if (!waitforstart)
            {
                Invoke("movestart", 3.4f);
                waitforstart = true;
            }
            Vector3 pos = this.gameObject.transform.position;
            if (!_Demo_Start.demostart && !_FadeStick_Demo.fadestart && move_start)
            {
                this.transform.position += (replica_pos - pos) / 40;
            }
            if (_FadeStick_Demo.fadestart && i < 21)
            {
                _you.gameObject.GetComponent<Text>().color = new Color(0, 0, 0, 0.015f * (float)(20 - i));
                i += 1;
            }
            else if (i > 20)
            {
                _you.gameObject.GetComponent<Text>().color = new Color(0, 0, 0, 0);
            }

            if (_Demo_Start.demostart && once)
            {
                moving = true;
                once = false;
                start_pos = this.transform.position;
            }
            if (moving)
            {
                if (this.gameObject.transform.position.x < goal1.transform.position.x)
                {
                    pos.x += (goal1.transform.position.x - start_pos.x) * Time.deltaTime / 3.0f;
                }
                else if (this.gameObject.transform.position.y < goal2.transform.position.y)
                {
                    pos.y += (goal2.transform.position.y - start_pos.y) * Time.deltaTime / 3.0f;
                }
                else if (this.gameObject.transform.position.x < goal3.transform.position.x)
                {
                    pos.x += (goal3.transform.position.x - goal1.transform.position.x) * Time.deltaTime / 3.0f;
                }
                else
                {
                    Explanation_System.jumptonext(3.0f);
                    moving = false;
                }
                this.gameObject.transform.position = pos;

            }
        }
        void movestart()
        {
            move_start = true;
        }

    }
}