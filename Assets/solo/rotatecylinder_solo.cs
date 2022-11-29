using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoEmbodimentSystem
{
    public class rotatecylinder_solo : MonoBehaviour
    {
        [SerializeField] collision_judgemnt _collision_Judgemnt;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (_collision_Judgemnt.readyforgame_me)
            {
                this.transform.Rotate(new Vector3(0, 0, 1), 180 * Time.deltaTime);
            }
        }
    }
}
