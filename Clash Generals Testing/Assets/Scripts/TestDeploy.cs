using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class TestDeploy : MonoBehaviour, IPointerDownHandler
{
    public bool mouseDown = false;

    public GameObject targetPrefab;
    public GameObject unitToSpawnPrefab;
    public GameObject targetObj;
    public Vector3 destination;
    public float cost;

    Vector3 GetMousePos()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = 30;
        pos = Camera.main.ScreenToWorldPoint(pos);

        Debug.Log("Mouse Position: " + pos);
        return pos;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (ResourceController.master.GetValue() > cost)
        {
            targetObj = Instantiate(targetPrefab, GetMousePos(), Quaternion.identity);
            mouseDown = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
	    if (mouseDown)
	    {
	        if (Input.GetKeyUp(KeyCode.Mouse0))
	        {
	            mouseDown = false;
	            GameObject temp = Instantiate(unitToSpawnPrefab, targetObj.transform.position, Quaternion.identity);
	            temp.GetComponent<NavMeshAgent>().destination = destination;
                Destroy(targetObj);
	            ResourceController.master.Modify(-.3f);
	        }
	        else
	        {
	            targetObj.transform.position = GetMousePos();
	        }
	    }
	}
}
