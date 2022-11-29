using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoEmbodimentSystem
{
    public class dynamiccontrol : MonoBehaviour
    {
        public bool collisionfordynamic = false;
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
            /*if (Collision_Judgement.start1)
            {
                collisionfordynamic = false;
            }*/
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "hitstick" && Collision_Judgement.start_game)
            {
                collisionfordynamic = true;
            }
        }
    }
}