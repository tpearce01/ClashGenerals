using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterAggroRange : MonoBehaviour {

    [SerializeField]
    SimpleAI target;

    void OnTriggerEnter(Collider other) {
        Debug.Log("Found Target");
        target.inAggroRange = true;
        target.nav.destination = other.gameObject.transform.position;
        target.target = other.gameObject.GetComponent<Unit>();
    }

    void OnTriggerExit(Collider other) {
        target.inAggroRange = false;
    }
}
