using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoEmbodimentSystem
{
    public class movecylinder_solo : MonoBehaviour
    {
        private float _time = 0;
        Vector3 defalutpos;
        [SerializeField] collision_judgemnt _collision_Judgemnt;
        public float _timedelay = 0;
        // Start is called before the first frame update
        void Start()
        {
            defalutpos = this.transform.position;
            _time = _timedelay;
        }

        // Update is called once per frame
        void Update()
        {
            if (_collision_Judgemnt.readyforgame_me)
            {
                _time += Time.deltaTime;
            }
            if (_time % 2 < 1.0f)
            {
                this.transform.position = defalutpos + new Vector3(0, (_time % 2) * 0.1f, 0);
            }
            else
            {
                this.transform.position = defalutpos + new Vector3(0, (2 - _time % 2) * 0.1f, 0);
            }
        }
    }
}
