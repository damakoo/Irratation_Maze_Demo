using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoEmbodimentSystem
{
    public class exp3 : MonoBehaviour
    {
        private bool once = true;
        explanation_system Explanation_System;
        // Start is called before the first frame update
        void Start()
        {
            Explanation_System = GameObject.Find("Explanation/ExplanationManager").gameObject.GetComponent<explanation_system>();
        }

        // Update is called once per frame
        void Update()
        {
            if (once)
            {
                Explanation_System.jumptonext(15.0f);
                once = false;
            }

        }
    }

}