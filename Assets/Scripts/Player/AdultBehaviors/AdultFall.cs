using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdultFall : StateMachineBehaviour
{
    [SerializeField] private Rigidbody2D adultRb;
    [SerializeField] private Adult adult;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        adultRb = GameObject.FindGameObjectWithTag("Adult").GetComponent<Rigidbody2D>();
        adult = GameObject.FindGameObjectWithTag("Adult").GetComponent<Adult>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (adult.IsGrounded() && Mathf.Abs(adultRb.velocity.x) < .1f)
        {
            animator.SetInteger("AdultState", 0);
        }
        else if (adult.IsGrounded() && Mathf.Abs(adultRb.velocity.x) > .1f)
        {
            animator.SetInteger("AdultState", 1);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
