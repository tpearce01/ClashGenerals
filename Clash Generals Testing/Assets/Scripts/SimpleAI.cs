using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 SimpleAI 
 Purpose: Controls unit attack behavior
 Attach: all units
     
     */
public class SimpleAI : MonoBehaviour{
    public byte teamNumber;                         //Indicates team number to check for ally/enemy
    [SerializeField] private AttackType attackType; //Melee or ranged attack type
    public bool inAttackRange;                      //Is the unit in range for an attack?
    public bool inAggroRange;                       //Is the unit pursuing another target?
    [SerializeField] private float attackSpeed;     //Seconds between each attack
    private float attackTimer;                      //Time until the next attack
    public Unit target;                       //Current in range target to attack
    public NavMeshAgent nav;                        //Nav Mesh Agent for controlling destination
    [SerializeField] int damage;
    [SerializeField] Vector3 destination;
    bool resetTarget;

    void Start() {
        nav.destination = destination;
    }

    // Update is called once per frame
    void Update (){
	    Attack();
	}

    void Attack(){
        if (target == null) {
            ResetTarget();
            return;
        }

        if (inAttackRange){
            if (attackTimer <= 0){
                attackTimer = attackSpeed;  //Reset timer for next attack
                if (attackType == AttackType.Ranged){
                    //Spawn Projectile
                    Debug.Log("Ranged Attack");
                    if (target.health <= damage) {
                        resetTarget = true;
                    }
                    target.ModifyHealth(-damage);
                    if (resetTarget) {
                        ResetTarget();
                        resetTarget = false;
                    }
                }
                else{
                    //Attack
                    Debug.Log("Other attack");
                }
            }
            else{
                attackTimer -= Time.deltaTime;
            }
        }
    }

    void ResetTarget() {
        inAggroRange = false;
        inAttackRange = false;
        target = null;
        nav.destination = destination;
    }

}

public enum AttackType {
    Ranged = 0,
    Melee = 1
}
