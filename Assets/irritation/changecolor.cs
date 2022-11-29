using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoEmbodimentSystem
{
    public class changecolor : MonoBehaviour
    {
        GameObject gameobject0;
        collision_judgemnt Collision_Judgement;

        // Start is called before the first frame update
        void Start()
        {
            gameobject0 = GameObject.Find("irritation_system/GameObject");
            Collision_Judgement = gameobject0.gameObject.GetComponent<collision_judgemnt>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Collision_Judgement.collision == 0)
            {
                this.GetComponent<Renderer>().material.color = Color.white;
            }
            else
            {
                this.GetComponent<Renderer>().material.color = Color.magenta;
            }

        }

        private void OnTriggerStay(Collider other)
        {
            if (Collision_Judgement.collision == 0 && other.name == "hitstick" && Collision_Judgement.start_game == true)
            {
                Collision_Judgement.collision = 1;

            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (Collision_Judgement.collision == 1 && other.name == "hitstick" && Collision_Judgement.start_game == true)
            {
                Collision_Judgement.collision = 0;
            }
                
        }
    }
}