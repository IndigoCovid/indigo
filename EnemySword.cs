using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour
{
    Transform target;
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {

        target = GameObject.FindGameObjectWithTag("Player").transform;


        if (target.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1,1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
