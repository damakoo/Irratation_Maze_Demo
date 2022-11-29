using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoEmbodimentSystem
{
    public class movecylinder2 : MonoBehaviour
    {
        [SerializeField] showtime _showtime;
        Vector3 defalutpos;
        // Start is called before the first frame update
        void Start()
        {
            defalutpos = this.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (_showtime.standard_time % 5 < 2.5f)
            {
                this.transform.position = defalutpos - new Vector3(0.2f * (_showtime.standard_time % 5), 0, 0);
            }
            else
            {
                this.transform.position = defalutpos - new Vector3(0.2f * (5 - _showtime.standard_time % 5), 0, 0);
            }
        }
    }
}