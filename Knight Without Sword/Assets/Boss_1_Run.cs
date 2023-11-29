using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Boss_1_Run : StateMachineBehaviour
{
    [Header("Componet")]
    [SerializeField] private Boss_1Controller _controller;
    [SerializeField] private NavMeshAgent navMeshAgent;
    private bool faceRight = true;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _controller = animator.GetComponentInParent<Boss_1Controller>();
        navMeshAgent = animator.GetComponentInParent<NavMeshAgent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        navMeshAgent.isStopped = false;
        _controller.EnemyMove();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        navMeshAgent.isStopped = true;
    }

}
