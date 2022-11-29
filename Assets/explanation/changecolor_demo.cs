using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoEmbodimentSystem
{
    public class changecolor_demo : MonoBehaviour
    {
        [SerializeField]
        private timelimit_demo _Timelimit_Demo;
        private int collisiontime_before = 0;
        // Update is called once per frame
        void Update()
        {
            if (collisiontime_before != _Timelimit_Demo.time_collision)
            {
                this.GetComponent<Renderer>().material.color = Color.magenta;
                Invoke("getwhite", 1.0f);
                collisiontime_before = _Timelimit_Demo.time_collision;
            }

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "hitstick_demo")
            {
                _Timelimit_Demo.collision_demo = true;
                _Timelimit_Demo.time_collision += 1;
            }
        }
        void getwhite()
        {
            this.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
