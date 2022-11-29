using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CoEmbodimentSystem
{
    public class movestick_failed : MonoBehaviour
    {
        private bool waitforstart = false;
        private bool move_start = false;
        [SerializeField]
        private timelimit_demo _TimeLimit_Demo;
        explanation_system Explanation_System;
        [SerializeField] GameObject goal1;
        [SerializeField] GameObject goal2;
        [SerializeField] GameObject goal3;
        Vector3 start_pos;
        // Start is called before the first frame update
        void Start()
        {
            Explanation_System = GameObject.Find("Explanation/ExplanationManager").gameObject.GetComponent<explanation_system>();
            start_pos = this.transform.position;
        }
        // Update is called once per frame
        void Update()
        {
            Vector3 pos = this.gameObject.transform.position;
            if (!waitforstart)
            {
                Invoke("movestart", 3.0f);
                waitforstart = true;
            }
            if (move_start)
            {
                if (_TimeLimit_Demo.time_collision == 0)
                {
                    pos.x += (goal1.transform.position.x - start_pos.x) * Time.deltaTime / 5.0f;
                }
                else if (_TimeLimit_Demo.time_collision == 1 && this.gameObject.transform.position.x > goal1.transform.position.x)
                {
                    pos.x -= (goal1.transform.position.x - start_pos.x) * Time.deltaTime / 4.0f;
                }
                else if (_TimeLimit_Demo.time_collision == 1)
                {
                    pos.y += (goal2.transform.position.y - start_pos.y) * Time.deltaTime / 4.0f;
                }
                else if (_TimeLimit_Demo.time_collision == 2 && this.gameObject.transform.position.y > goal2.transform.position.y)
                {
                    pos.y -= (goal2.transform.position.y - start_pos.y) * Time.deltaTime / 4.0f;
                }
                else if (this.gameObject.transform.position.x < goal3.transform.position.x)
                {
                    pos.x += (goal3.transform.position.x - goal1.transform.position.x) * Time.deltaTime / 3.0f;
                }
                else
                {
                    Explanation_System.jumptonext(3.0f);
                    move_start = false;
                }
                this.transform.position = pos;
            }
        }
        void movestart()
        {
            move_start = true;
        }

    }
}