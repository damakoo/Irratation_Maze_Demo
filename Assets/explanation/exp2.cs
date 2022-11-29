using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CoEmbodimentSystem
{
    public class exp2 : MonoBehaviour
    {

        explanation_system Explanation_System;
        [SerializeField] GameObject calibrate;
        [SerializeField] GameObject finish_calibrate;
        private bool once = false;

        // Start is called before the first frame update
        void Awake()
        {
            Explanation_System = GameObject.Find("Explanation/ExplanationManager").gameObject.GetComponent<explanation_system>();
        }
        private void OnEnable()
        {
            finish_calibrate.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (OVRInput.GetDown(OVRInput.Button.One) && !once)//(OVRInput.GetControllerWasRecentered())
            {
                OVRManager.display.RecenterPose();
                once = true;
                calibrate.SetActive(false);
                finish_calibrate.SetActive(true);
                Explanation_System.jumptonext(3.0f);
            }
        }
    }
}
