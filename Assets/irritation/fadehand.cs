using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoEmbodimentSystem
{
    public class fadehand : MonoBehaviour
    {
        GameObject gameobject0;
        collision_judgemnt Collision_Judgemnt;
        public GameObject hand1;
        private bool appeared = true;
        // Start is called before the first frame update
        void Start()
        {
            gameobject0 = GameObject.Find("irritation_system/GameObject");
            Collision_Judgemnt = gameobject0.gameObject.GetComponent<collision_judgemnt>();
        }

        // Update is called once per frame
        void Update()
        {
            if (appeared && Collision_Judgemnt.readyforgame_me)
            {
                Invoke("fade", 0.1f);
                appeared = false;
            }
        }
        void fade()
        {
            hand1.SetActive(false);
        }
        void appear()
        {
            hand1.SetActive(true);
            appeared = true;
        }
    }
}
