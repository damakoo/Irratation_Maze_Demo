using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoEmbodimentSystem
{
    public class changecolorforsamplemove : MonoBehaviour
    {
        GameObject gameobject0;
        [SerializeField] collision_judgemnt Collision_Judgement;

        // Start is called before the first frame update
        void Start()
        {
            //gameobject0 = GameObject.Find("irritation_system/GameObject");
            //Collision_Judgement = gameobject0.gameObject.GetComponent<collision_judgemnt>();
        }

        // Update is called once per frame
        void Update()
        {


        }

        private void OnTriggerEnter(Collider other)
        {
            if (Collision_Judgement.collision == 1 && other.name == "hitstick" && Collision_Judgement.start_game == true)
            {
                Collision_Judgement.collision = 0;
                Debug.Log("Enter");
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.name == "hitstick" && Collision_Judgement.start_game == true)
            {
                Collision_Judgement.collision = 1;
                Debug.Log("Exit");
            }
        }
    }
}