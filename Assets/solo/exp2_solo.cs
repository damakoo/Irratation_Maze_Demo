using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoEmbodimentSystem
{
    public class exp2_solo : MonoBehaviour
    {

        explanationsystem_solo Explanation_System;
        [SerializeField] GameObject calibrate;
        [SerializeField] GameObject finish_calibrate;
        private bool once = false;

        // Start is called before the first frame update
        void Awake()
        {
            Explanation_System = GameObject.Find("Explanation/ExplanationManager").gameObject.GetComponent<explanationsystem_solo>();
        }
        private void OnEnable()
        {
            finish_calibrate.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch) && !once)//(OVRInput.GetControllerWasRecentered())
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

