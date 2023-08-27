using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    private GameObject player;
    private Vector3 lastKnowPos;
    public GameObject Player { get => player; }
    public NavMeshAgent Agent { get => agent; }
    public Vector3 LastKnowPost { get => lastKnowPos; set => lastKnowPos = value; }
    [SerializeField] private string currentState;

    public Path path;

    [Header("Sight Values")]
    public float sightDistance = 200f;
    public float depthOfView = 85f;
    public GameObject eyeHeight;

    [Header("Weapon Values")]
    public Transform gunBarrel;
    [Range(0.1f, 10f)]
    public float fireRate;
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialise();
        player = GameObject.FindGameObjectWithTag("Player");
        eyeHeight = GameObject.Find("Eyes");

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
                Vector3 targetDirection = player.transform.position - transform.position;
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);

                if(angleToPlayer >= -depthOfView && angleToPlayer <= depthOfView)
                {
                    Ray ray = new Ray(transform.position, targetDirection);

                    RaycastHit hitInfor = new RaycastHit();
                    if(Physics.Raycast(ray, out hitInfor, sightDistance))
                    {
                        if(hitInfor.transform.gameObject == player)
                        {
                            Debug.DrawRay(eyeHeight.transform.position, ray.direction * sightDistance);
                            return true;                            
                        }
                    }
                    
                }
            }
        }

        return false;
    }
}