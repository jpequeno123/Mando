using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1_move : StateMachineBehaviour
{
//
//
//    public float speed = 2.5f;
//    public float attackRange = 2.02f;
//
//    //public float Speed = rb.MovePosition(newPos);
//
//    Transform player;
//    Rigidbody2D rb;
//    Boss1 boss1;
//
//    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
//    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {
//        player = GameObject.FindGameObjectWithTag("Player").transform;
//        rb = animator.GetComponent<Rigidbody2D>();
//        boss1 = animator.GetComponent<Boss1>();
//        animator.SetBool("bruh1", true);
//    }
//
//    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
//    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {
//        boss1.LookAtPlayer();
//        Vector2 target = new Vector2(player.position.x, rb.position.y);
//        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
//        rb.MovePosition(newPos);
//    }
//
//    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
//    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {
//        animator.SetBool("bruh1", false);
//    }
}
