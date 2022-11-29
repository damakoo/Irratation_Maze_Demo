using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class samplemovefordemo : MonoBehaviour
{
    Vector3 startpos = new Vector3(-0.419f, 1.383f, 0.648f);
    Vector3 endpos = new Vector3(-0.419f, 0.95f, 0.648f);
    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = startpos;
    }

    // Update is called once per frame
    void Update()
    {
        if(time % 4 < 2)
        {
            this.transform.position = startpos + (endpos - startpos) * (time % 4) / 2;
        }
        else
        {
            this.transform.position = endpos + (startpos - endpos) * (time % 4) / 2;
        }
        time += Time.deltaTime;
    }
}
