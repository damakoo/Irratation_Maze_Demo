using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoEmbodimentSystem
{

    public class movecylinder : MonoBehaviour
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
            
            if (_showtime.standard_time % 2 < 1.0f)
            {
                this.transform.position = defalutpos + new Vector3(0, (_showtime.standard_time % 2) * 0.1f, 0);
            }
            else
            {
                this.transform.position = defalutpos + new Vector3(0, (2 -_showtime.standard_time % 2) * 0.1f, 0);
            }
        }
    }
}
