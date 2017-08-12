using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 SimpleAI 
 Purpose: Controls unit attack behavior
 Attach: all units
     
     */
public class SimpleAI : MonoBehaviour
{
    public byte teamNumber;                         //Indicates team number to check for ally/enemy
    [SerializeField] private AttackType attackType; //Melee or ranged attack type
    private bool inRange;                           //Is the unit in range for an attack?
    private bool aggro;                             //Is the unit pursuing another target?
    [SerializeField] private float attackSpeed;     //Seconds between each attack
    private float attackTimer;                      //Time until the next attack
    private GameObject target;                      //Current in range target to attack
    [SerializeField] private NavMeshAgent nav;      //Nav Mesh Agent for controlling destination
    [SerializeField] private int moveSpeed;         //Movement speed
	
	// Update is called once per frame
	void Update ()
	{
	    Attack();
	}

    void Attack()
    {
        if (inRange)
        {
            if (attackTimer <= 0)
            {
                attackTimer = attackSpeed;  //Reset timer for next attack
                if (attackType == AttackType.Ranged)
                {
                    //Spawn Projectile
                }
                else
                {
                    //Attack
                }
            }
            else
            {
                attackTimer -= Time.deltaTime;
            }
        }
    }

    /// <summary>
    /// MoveIfAggro
    /// If not in range to attack but has a target to pursue, move toward the target
    /// </summary>
    void MoveIfAggro()
    {
        if (!inRange && aggro)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position,
                moveSpeed*Time.deltaTime);
        }
    }

    /*
     OnTriggerEnter 
     Check if other is a valid target. If it is, then set inRange to true. This will cause the unit to enter attack mode

        !!Caution: inRange should be set to false if the target leaves range or is killed.
         */
    void OnTriggerEnter(Collider other)
    {
        //if(other.gameObject.GetComponent<SimpleAI>().teamNumber != teamNumber){
        //In range for attacks
        inRange = true;
        target = other.gameObject;
        //Clear nav mesh & move toward
        nav.isStopped = true;
        //}
    }

    /*
     OnTriggerExit
     Check if current target leaves range. If it does, clear target and set inRange to false
         */
    void OnTriggerExit(Collider other)
    {
        if (target != null && other.gameObject == target)
        {
            inRange = false;
            target = null;
        }
    }
}

public enum AttackType
{
    Ranged = 0,
    Melee = 1
}
