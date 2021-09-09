using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAttack1 : StateMachineBehaviour
{

    Rigidbody2D rb;
    Boss1 boss1;
    Boss1_jumpAttack JumpDamage;
    private bool isjumping;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss1 = animator.GetComponent<Boss1>();
        rb = animator.GetComponent<Rigidbody2D>();
        boss1.JumpAttack();
        JumpDamage = animator.GetComponent<Boss1_jumpAttack>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        isjumping = animator.GetBool("IsRunning");
        if (isjumping == false)
        {
            animator.SetBool("IsJumpingAt", false);
        }
        else
        {
            animator.SetBool("IsJumpingAt", true);
        }
        if (rb.velocity.y <= 0)
        {
            boss1.bruhJumpAttack();
            JumpDamage.jAttack();
            animator.SetBool("IsJumpingAt", false);
        }

    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log("O animator do salto de attaque desligou");
    }
}
