using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CoEmbodimentSystem{
    public class fadeui : MonoBehaviour
    {
        [SerializeField] GameObject _weightshiftui;
        

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if(_weightshiftui.activeSelf){
                _weightshiftui.SetActive(false);
            }
        }
    }
}