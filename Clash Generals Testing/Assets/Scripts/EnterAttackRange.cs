using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterAttackRange : MonoBehaviour {

    [SerializeField]
    SimpleAI target;

    void OnTriggerEnter(Collider other) {
        Debug.Log("Attacking Target");
        target.inAttackRange = true;
        target.nav.ResetPath();
    }

    void OnTriggerExit(Collider other) {
        target.inAttackRange = false;
    }
}
