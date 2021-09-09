using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boss1_Jump : StateMachineBehaviour
{


    //      Rigidbody2D rb;
    //      private bool flipped;


    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        //        flipped = animator.GetBool("Iflipped");
        //
        //        player = GameObject.FindGameObjectWithTag("Player").transform;
        //
        //        rb = animator.GetComponent<Rigidbody2D>();
        //        if (flipped == true)
        //        {
        //            rb.AddForce(new Vector2(-600f, 1000f));
        //        }
        //        if (flipped == false)
        //        {
        //            rb.AddForce(new Vector2(300f, 1000f));
        //        }
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //if (m_Grounded == true && bump==true)// && "IsJumping" == true)
        //{
        //enemy.
        //    animator.SetBool("Isjumping", false);
        //}
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //rb.AddForce( Vector2.up* 0f);
        //       if (m_Grounded == true)// && "IsJumping" == true)
        //       {
        //           enemy.animator.SetBool("Isjumping", false);
        //       }
        // = false;
    }
}
