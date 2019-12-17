using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Controls the enemy AI
public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;          //Detection range for player

    Transform target;                       //refernce to player

    NavMeshAgent agent;                     //reference to the nav mesh agent

    CharacterCombat combat;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;

        agent = GetComponent<NavMeshAgent>();

        combat = GetComponent<CharacterCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        //Distance from the target
        float distance = Vector3.Distance(target.position, transform.position);

        //If inside the lookRadius
        if(distance <= lookRadius)
        {
            //Move towards the target
            agent.SetDestination(target.position);

            //If within attacking distance
            if(distance <= agent.stoppingDistance)
            {
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if (targetStats != null)
                {
                    //attack the target(player)
                    combat.Attack(targetStats);
                }
                
                //face the target
                FaceTarget();
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}
