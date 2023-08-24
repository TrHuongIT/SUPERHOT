using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    public NavMeshAgent Agent { get => agent; }
    [SerializeField] private string currentState;

    public Path path;

    private GameObject player;
    public float sightDistance = 20f;
    public float depthOfView = 85f;
    public float eyeHeight;

    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialise();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        CanSeePlayer();
        currentState = stateMachine.activateState.ToString();
    }

    public bool CanSeePlayer()
    {
        if(player != null)
        {
            if(Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);

                if(angleToPlayer >= -depthOfView && angleToPlayer <= depthOfView)
                {
                    Ray ray = new Ray(transform.position + Vector3.up*eyeHeight, targetDirection);

                    RaycastHit hitInfor = new RaycastHit();
                    if(Physics.Raycast(ray, out hitInfor, sightDistance))
                    {
                        if(hitInfor.transform.gameObject == player)
                        {
                            Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                            return true;                            
                        }
                    }
                    
                }
            }
        }

        return false;
    }
}