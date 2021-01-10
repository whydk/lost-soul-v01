using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedIdle : StateMachineBehaviour
{
    Transform playerPos;
    EnemyRanged enemy;
    public float timeBetweenAttacks;
    float time;
    public bool followPlayer = false;
    public bool playerInRange;
    public float speed;
    Rigidbody rigidbody;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = animator.GetComponent<EnemyRanged>();
        rigidbody = animator.GetComponent<Rigidbody>();
        time = timeBetweenAttacks;
        animator.GetComponentInChildren<ChangeLightColor>().TurnOnLight();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time -= Time.deltaTime;
        followPlayer = animator.GetComponent<EnemyRanged>().followPlayer;
        playerInRange = animator.GetComponent<EnemyRanged>().playerInRange;
        if (playerInRange && followPlayer)
        {
            enemy.ChangeRotationToPlayer();
            if (time <= 0f)
            {
                animator.SetTrigger("Attack");
                time = timeBetweenAttacks;
            }
        }
        else if(!playerInRange && followPlayer)
        {
            enemy.ChangeRotationToPlayer();
            Vector3 targetPlayer = new Vector3(playerPos.position.x, playerPos.position.y, 0);
            Vector3 newPos = Vector3.MoveTowards(rigidbody.position, targetPlayer, speed * Time.fixedDeltaTime);
            rigidbody.MovePosition(newPos);
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
