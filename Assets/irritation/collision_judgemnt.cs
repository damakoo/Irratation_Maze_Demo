using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoEmbodimentSystem
{
    public class collision_judgemnt : MonoBehaviour
    {

        public int collision = 0;
        public bool finish_explanation = false;
        public bool start1 = false;
        public bool start_game = false;
        public bool readyforgame_me = false;
        public bool readygforgame_opponent = false;
        public int changed1 = 1;
        private bool vibration = false;
        public bool soloplay = false;
        public int collisionnumber = 0;
        private bool fading = false;
        private bool once = true;
        public float collisiontime = 0;

        [SerializeField] GameObject root1;
        [SerializeField] GameObject _Sphere;
        // Start is called before the first frame update
 
        // Update is called once per frame
        void Update()
        {

            if (collision == 1)
            {
                collisiontime += Time.deltaTime;
                OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
                if (vibration)
                {
                    vibration = false;
                }
            }
            else if (collision == 0 && !vibration)
            {
                OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
                vibration = true;
            }

        }
        private void FixedUpdate()
        {
            
        }

    }
}
