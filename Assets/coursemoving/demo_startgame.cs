using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoEmbodimentSystem {
    public class demo_startgame : MonoBehaviour
    {
        [SerializeField] collision_judgemnt _collision_Judgemnt;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (OVRInput.GetDown(OVRInput.Button.Three))
            {
                _collision_Judgemnt.start_game = true;
                _collision_Judgemnt.readyforgame_me = true;
            }
        }
    }
}