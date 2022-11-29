using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoEmbodimentSystem
{
    public class fadestick : MonoBehaviour
    {
        GameObject gameobject0;
        collision_judgemnt Collision_Judgemnt;
        private float fadetime = 1.0f;
        int i = 0;
        private Vector3 initialscale;
        // Start is called before the first frame update
        void Start()
        {
            gameobject0 = GameObject.Find("irritation_system/GameObject");
            Collision_Judgemnt = gameobject0.gameObject.GetComponent<collision_judgemnt>();
            initialscale = this.transform.localScale;

        }

        // Update is called once per frame
        void Update()
        {
            if (Collision_Judgemnt.readyforgame_me)
            {
                if (i < 21)
                {
                    //this.gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, 100, 255, 0.1f + 0.5f * i / 20);
                    this.transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);
                    i += 1;
                }
                else if (i < 41)
                {
                    //this.gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, 100, 255, 0.6f - (i - 20) * 0.6f / 20);
                    this.transform.localScale -= new Vector3(0.001f, 0.001f, 0.001f);
                    i += 1;
                }
                else
                {
                    this.gameObject.GetComponent<MeshRenderer>().material.color = new Color(255, 255, 255, 0);
                    this.transform.localScale = initialscale;
                }

            }
            else
            {
                i = 0;
            }
        }
    }
}