using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grip : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        animator.SetInteger("Pose",1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
