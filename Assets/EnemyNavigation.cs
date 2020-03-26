using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour {

    public Transform target;
    private NavMeshAgent agent;
    Animator animator;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        agent.SetDestination(target.position);
        animator.SetBool("moving", agent.remainingDistance > 10 * agent.radius);
    }

}
