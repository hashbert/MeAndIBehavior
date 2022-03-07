using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkBehavior : StateMachineBehaviour
{
    [SerializeField] private Rigidbody2D kidRb;
    [SerializeField] private Kid kid;
    //[SerializeField] private GroundCheck groundCheck;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        kidRb = GameObject.FindGameObjectWithTag("Kid").GetComponent<Rigidbody2D>();
        kid = GameObject.FindGameObjectWithTag("Kid").GetComponent<Kid>();
        //groundCheck = GameObject.FindGameObjectWithTag("Kid").transform.Find("GroundCheck").GetComponent<GroundCheck>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //if (groundCheck.isGrounded && Mathf.Abs(kidRb.velocity.x) < .1f)
        //{
        //    animator.SetInteger("KidState", 0);
        //}
        //else if (!groundCheck.isGrounded && kidRb.velocity.y > 0)
        //{
        //    animator.SetInteger("KidState", 2);
        //}
        //else if (!groundCheck.isGrounded && kidRb.velocity.y < 0)
        //{
        //    animator.SetInteger("KidState", 3);
        //}

        if (kid.IsGrounded() && Mathf.Abs(kidRb.velocity.x) < .1f)
        {
            animator.SetInteger("KidState", 0);
        }
        else if (!kid.IsGrounded() && kidRb.velocity.y > 0)
        {
            animator.SetInteger("KidState", 2);
        }
        else if (!kid.IsGrounded() && kidRb.velocity.y < 0)
        {
            animator.SetInteger("KidState", 3);
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
