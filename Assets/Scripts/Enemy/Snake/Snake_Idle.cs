using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_Idle : StateMachineBehaviour
{
    Transform playerPos;
    SnakeBoss bossScript;
    public float timeBetweenAttacks;
    float time;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        bossScript = animator.GetComponent<SnakeBoss>();
        time = timeBetweenAttacks;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time -= Time.deltaTime;
        if(time <= 0f)
        {
            animator.SetTrigger("Attack");
            time = timeBetweenAttacks;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
