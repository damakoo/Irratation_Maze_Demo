using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CoEmbodimentSystem
{
    public class showtime : MonoBehaviour
    {
        [SerializeField] FusionBodyTransformCalculator _fusionBodyTransformCalculator;
        public float standard_time;
        private bool start = false;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (_fusionBodyTransformCalculator.connectionjudge)
            {
                start = true;
            }
            if (start)
            {
                standard_time += Time.deltaTime;
            }
        }
    }
}