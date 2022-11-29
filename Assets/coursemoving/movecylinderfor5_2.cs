using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoEmbodimentSystem
{
    public class movecylinderfor5_2 : MonoBehaviour
    {
        private Vector3 startpos;
        private float _time = 0;
        [SerializeField] collision_judgemnt _collision_Judgemnt;
        // Start is called before the first frame update
        void Start()
        {
            startpos = this.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            this.transform.position = startpos + new Vector3(((_time + 1.5f) % 4.5f) / 10, 0, 0);
            if (_collision_Judgemnt.readyforgame_me)
            {
                _time += Time.deltaTime;
            }
        }
    }
}
