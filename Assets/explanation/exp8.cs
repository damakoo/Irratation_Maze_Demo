using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoEmbodimentSystem
{
    public class exp8 : MonoBehaviour
    {
        [SerializeField] mingturn _mingturn;
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
                _mingturn.changestage(2f, 0.5f, 3.5f, 1);
                Explanation_System.jumptonext(3.0f);
                once = false;
            }

        }
    }
}
