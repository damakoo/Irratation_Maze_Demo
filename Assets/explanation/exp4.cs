using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoEmbodimentSystem
{
    public class exp4 : MonoBehaviour
    {
        explanation_system Explanation_System;
        // Start is called before the first frame update
        void Start()
        {
            Explanation_System = GameObject.Find("Explanation/ExplanationManager").gameObject.GetComponent<explanation_system>();
        }

        // Update is called once per frame
        void Update()
        {
            Explanation_System.jumptonext(20.0f);
        }
    }
}