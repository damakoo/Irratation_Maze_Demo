using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_check : MonoBehaviour
{
    public bool collisioned;

    private void OnTriggerEnter(Collider other)
    {
        collisioned = true;
    }
    private void OnTriggerExit(Collider other)
    {
        collisioned = false;
    }
}
