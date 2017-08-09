using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeBoxCollider : MonoBehaviour {

    private void OnEnable() {
        GetComponent<BoxCollider2D>().size = new Vector2(GetComponent<RectTransform>().sizeDelta.x,GetComponent<RectTransform>().sizeDelta.x * 1.167f);
    }
}
