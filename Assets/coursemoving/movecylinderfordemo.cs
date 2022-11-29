using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoEmbodimentSystem
{
    public class movecylinderfordemo : MonoBehaviour
    {
        private float _time = 0;
        Vector3 defalutpos;
        public float _delaytime = 0;
        [SerializeField] collision_judgemnt _collision_Judgemnt;
        // Start is called before the first frame update
        void Start()
        {
            defalutpos = this.transform.position;
            _time = _delaytime;
        }

        // Update is called once per frame
        void Update()
        {
            if (_time % 2 < 1.0f)
            {
                this.transform.position = defalutpos + new Vector3((_time % 2) * 0.4f, 0, 0);
            }
            else
            {
                this.transform.position = defalutpos + new Vector3((2 - _time % 2) * 0.4f, 0, 0);
            }
            if (_collision_Judgemnt.readyforgame_me)
            {
                _time += Time.deltaTime;
            }
        }
    }
}
