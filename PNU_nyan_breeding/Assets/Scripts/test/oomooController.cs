using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oomooController : MonoBehaviour
{
    public Animator animator;
    public float animSpeed=0.5f;
    float horizontal;
    void Start()
    {
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animator.speed=animSpeed;
        Coloring();
    }

    void Coloring(){
        horizontal=Input.GetAxis("Horizontal");
        if(horizontal!=0){
            animator.SetBool("coloring",true);
        }else{
            animator.SetBool("coloring",false);
        }

    }

}
