using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FallBehavior : StateMachineBehaviour
{
    //[SerializeField] private GameObject kid;
    [SerializeField] private Rigidbody2D kidRb;
    [SerializeField] private Kid kid;
    //[SerializeField] private GroundCheck groundCheck;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //kid = GameObject.FindGameObjectWithTag("Kid");
        kid = GameObject.FindGameObjectWithTag("Kid").GetComponent<Kid>();
        kidRb = GameObject.FindGameObjectWithTag("Kid").GetComponent<Rigidbody2D>();
        //groundCheck = GameObject.FindGameObjectWithTag("Kid").transform.Find("GroundCheck").GetComponent<GroundCheck>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (kid.IsGrounded())
        {
            animator.SetInteger("KidState", 0);
        }
        else if (kidRb.velocity.y < 0.1f && kid.SpaceHeld)
        {
            animator.SetInteger("KidState", 4);
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
