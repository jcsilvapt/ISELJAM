using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class c_cutsceneCharacter : MonoBehaviour {

    [SerializeField] GameObject character;
    [SerializeField] List<Transform> waypoints;

    private Animator anim;
    private NavMeshAgent agent;

    private int waypointId = 0;
    private bool isWalking;
    private bool hasPath;

    private void Awake() {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        if (isWalking) {
            if(!hasPath) {
                agent.SetDestination(waypoints[0].position);
                anim.SetBool("isWalking", isWalking);
                hasPath = true;
            }

            if (agent.remainingDistance < 0.1f) {
                agent.isStopped = true;
                hasPath = false;
                if(waypointId <= waypoints.Count) {
                    waypointId++;
                } else {
                    isWalking = false;
                    anim.SetBool("isWalking", isWalking);
                }
            }
        } else {
            if(hasPath) {
                agent.ResetPath();
                hasPath = false;
                anim.SetBool("isWalking", isWalking);
            }
        }
    }

    public void SignalStartWalking() {
        transform.LookAt(waypoints[0].transform);
        anim.SetBool("isWalking", true);
    }

    public void SignalStopWalking() {
        isWalking = false;
    }

}
