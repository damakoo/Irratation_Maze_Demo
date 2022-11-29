using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoEmbodimentSystem
{
    public class fadestick_demo : MonoBehaviour
    {
        public bool fadestart;
        private float fadetime = 1.0f;
        int i = 0;
        Vector3 initial_scale;
        // Start is called before the first frame update
        void Start()
        {
            initial_scale = this.transform.localScale;
        }

        // Update is called once per frame
        void Update()
        {
            if (fadestart)
            {
                if (i < 21)
                {
                    //this.gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, 100, 255, 0.1f + 0.5f * i / 20);
                    this.transform.localScale += new Vector3(0.05f, 0.5f, 0.05f);
                    i += 1;
                }
                else if (i < 41)
                {
                    //this.gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, 100, 255, 0.6f - (i - 20) * 0.6f / 20);
                    this.transform.localScale -= new Vector3(0.05f, 0.5f, 0.05f);
                    i += 1;
                }
                else
                {
                    this.gameObject.GetComponent<Renderer>().material.color = new Color(255, 255, 255, 0);
                    this.transform.localScale = initial_scale;
                }

            }
            else
            {
                i = 0;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "hitstick_demo")
            {
                fadestart = true;
            }
        }
    }
}