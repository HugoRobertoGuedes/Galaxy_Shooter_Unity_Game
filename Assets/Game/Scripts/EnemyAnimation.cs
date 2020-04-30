﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Animator anim = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Animator anim = transform.GetComponent<Animator>();
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1){
            Destroy(this.gameObject);
        }
    }
}
