using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CoEmbodimentSystem
{
    public class movecylinder1 : MonoBehaviour
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
            if (_showtime.standard_time % 3 < 1.5f)
            {
                this.transform.position = defalutpos + new Vector3(0.06f * (_showtime.standard_time % 3), 0, 0);
            }
            else
            {
                this.transform.position = defalutpos + new Vector3(0.06f * (3 - _showtime.standard_time % 3), 0, 0);
            }
        }
    }
}