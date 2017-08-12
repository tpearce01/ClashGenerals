using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class TestNavigation : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navAgent;
    [SerializeField] private Text destinationText;
    [SerializeField] private Text currentPositionText;
    [SerializeField] private Vector3 destination;

	// Use this for initialization
	void Start () {
        currentPositionText.text = "Current Position: (" + gameObject.transform.position.x + ", " + gameObject.transform.position.y + ", " + gameObject.transform.position.z + ")";
        destinationText.text = "Destination: (" + gameObject.transform.position.x + ", " + gameObject.transform.position.y + ", " + gameObject.transform.position.z + ")";
    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Mouse0))
	    {
	        navAgent.destination = destination;
	        destinationText.text = "Destination: (" + destination.x + ", " + destination.y + ", " + destination.z + ")";
            Debug.Log("Destination Updated");
	    }

        currentPositionText.text = "Current Position: (" + gameObject.transform.position.x + ", " + gameObject.transform.position.y + ", " + gameObject.transform.position.z + ")";
    }
}
