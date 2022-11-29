using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoEmbodimentSystem
{
    public class fade_opponentstick : MonoBehaviour
    {
        GameObject gameobject0;
        collision_judgemnt Collision_Judgemnt;
        // Start is called before the first frame update
        void Start()
        {
            gameobject0 = GameObject.Find("irritation_system/GameObject");
            Collision_Judgemnt = gameobject0.gameObject.GetComponent<collision_judgemnt>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Collision_Judgemnt.readygforgame_opponent)
            {
                this.gameObject.GetComponent<Renderer>().material.color = new Color(255, 255, 255, 0f);
            }
            else
            {
                this.gameObject.GetComponent<Renderer>().material.color = new Color(255, 255, 255, 0.2f);
            }
        }
    }
}