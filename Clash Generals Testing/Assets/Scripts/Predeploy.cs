using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Predeploy : MonoBehaviour, IPointerDownHandler {
    public bool mouseDown = false;
    public GameObject targetPrefab;
    public GameObject unitToSpawnPrefab;
    public GameObject targetObj;
    public float cost;

    const float MIN_Z_DEPLOY = -6.5f;
    const float MAX_Z_DEPLOY = -2.5f;

    public void OnPointerDown(PointerEventData eventData) {
        if (ResourceController.master.GetValue() > cost) {
            targetObj = Instantiate(targetPrefab, GetMousePos(), Quaternion.identity);
            targetObj.transform.parent = gameObject.transform.parent.transform.parent.transform;
            mouseDown = true;
        }
    }

    Vector3 GetMousePos() {
        return Input.mousePosition;
    }

    Vector3 GetMousePosWorld() {
        Vector3 pos = Input.mousePosition;
        pos.z = 30;
        return Camera.main.ScreenToWorldPoint(pos);
    }

    void Update() {
        if (mouseDown) {
            if (Input.GetKeyUp(KeyCode.Mouse0)) {
                Vector3 deployPosition = GetMousePosWorld();
                mouseDown = false;
                Destroy(targetObj);

                //If the deployment position is in a valid location, spawn the unit
                if (deployPosition.z > MIN_Z_DEPLOY && deployPosition.z < MAX_Z_DEPLOY) {
                    GameObject temp = Instantiate(unitToSpawnPrefab, GetMousePosWorld(), Quaternion.identity);
                    ResourceController.master.Modify(-cost);
                }
            }
            else {
                targetObj.transform.position = GetMousePos();
            }
        }
    }
}
