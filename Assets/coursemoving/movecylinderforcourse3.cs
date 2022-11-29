using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoEmbodimentSystem
{
    public class movecylinderforcourse3 : MonoBehaviour
    {
        [SerializeField] collision_judgemnt _collision_Judgemnt;
        private Vector3 startpos;
        private float _time = 0;
        public float _timedelay = 0;
        public enum direction
        {
            LOWER, RIGHT,
        }
        public direction Direction;
        // Start is called before the first frame update
        void Start()
        {
            startpos = this.transform.position;
            _time = _timedelay;
        }

        // Update is called once per frame
        void Update()
        {
            if (Direction.ToString() == "RIGHT")
            {
                if (_time % 1.6 < 0.8f)
                {
                    this.transform.position = startpos;
                }
                else
                {
                    this.transform.position = new Vector3(startpos.x + 0.1f, startpos.y, startpos.z);
                }
            }
            else
            {
                if (_time % 1.6 < 0.8f)
                {
                    this.transform.position = startpos;
                }
                else
                {
                    this.transform.position = new Vector3(startpos.x, startpos.y - 0.1f, startpos.z);
                }
            }
            if (_collision_Judgemnt.readyforgame_me)
            {
                _time += Time.deltaTime;
            }
        }
    }
}