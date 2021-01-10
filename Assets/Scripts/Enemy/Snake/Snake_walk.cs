using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_walk : StateMachineBehaviour
{
    public float speed = 1f;
    public float attackRange = 1f;

    Transform playerPos;
    Rigidbody rigidbody;
    SnakeBoss bossScript;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody = animator.GetComponent<Rigidbody>();
        bossScript = animator.GetComponent<SnakeBoss>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossScript.ChangeRotationToPlayer();
        Vector3 targetPlayer = new Vector3(playerPos.position.x, playerPos.position.y, 0);
        Vector3 newPos = Vector3.MoveTowards(rigidbody.position, targetPlayer, speed * Time.fixedDeltaTime);
        rigidbody.MovePosition(newPos);

        if((Vector3.Distance(playerPos.position,rigidbody.position)) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
