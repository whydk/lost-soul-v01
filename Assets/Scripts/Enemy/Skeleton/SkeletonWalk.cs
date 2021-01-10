using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonWalk : StateMachineBehaviour
{
    public float speed = 0.5f;
    Vector3 wanderPosition;
    Rigidbody rigidbody;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        wanderPosition = animator.GetComponent<EnemyPatrol>().wanderPositions[0];
        rigidbody = animator.GetComponent<Rigidbody>();
        animator.GetComponent<EnemyPatrol>().wanderPositions.Reverse();
        animator.GetComponent<EnemyPatrol>().ChangeRotationPosition(wanderPosition);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!animator.GetBool("Run"))
        {
            Vector3 newPos = Vector3.MoveTowards(rigidbody.position, wanderPosition, speed * Time.fixedDeltaTime);
            rigidbody.MovePosition(newPos);
            if (newPos == wanderPosition)
            {
                animator.SetBool("Walk", false);
            }
        }
        else
        {
            Destroy(this);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Walk", false);
    }

}
