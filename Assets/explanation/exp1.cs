using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CoEmbodimentSystem
{

    public class exp1 : MonoBehaviour
    {
        [SerializeField] GameObject _weightshifter;
        [SerializeField] private FusionWeightController _fusionWeightController;
        [SerializeField] private FusionBodyTransformCalculator _fusionBodyTransformCalculator;
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
            if(!_weightshifter.activeSelf){
                _weightshifter.SetActive(true);
            }
            if (_fusionBodyTransformCalculator.connectionjudge && once)
            {
                Explanation_System.jumptonext(1.0f);
                once = false;
            }
        }
    }
}