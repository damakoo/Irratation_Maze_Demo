using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoEmbodimentSystem
{

    public class rotatecylinder : MonoBehaviour
    {
        [SerializeField] showtime _showtime;
        // Start is called before the first frame update
        private void OnEnable()
        {
            this.transform.Rotate(new Vector3(0, 0, 1), 180 * _showtime.standard_time);
        }

        // Update is called once per frame
        void Update()
        {
            this.transform.Rotate(new Vector3(0, 0, 1), 180 * Time.deltaTime);
        }
    }

}