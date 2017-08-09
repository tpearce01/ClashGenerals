using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BuildingSelection : MonoBehaviour
{

    [Header("Building Windows")]
    [SerializeField] private RectTransform right_building_menu;
    [SerializeField] private RectTransform left_building_menu;

    private float left_destination = 0.0f;
    private float right_destination = 0.0f;

    [SerializeField] private float speed;

    void OnEnable()
    {
        left_destination = -left_building_menu.sizeDelta.x;
        right_destination = right_building_menu.sizeDelta.x;
    }

    private void Update()
    {
        GetMouseClick();

        // Hide left the panel
        if (left_destination < 0.0f)
        {
            if (left_building_menu.localPosition.x > left_destination)
            {
                left_building_menu.localPosition = Vector2.MoveTowards(left_building_menu.localPosition, new Vector2(left_destination, left_building_menu.localPosition.y), speed * Time.deltaTime);
            }
        }
        else if (left_destination == 0.0f)
        {
            if (left_building_menu.transform.localPosition.x < left_destination)
            {
                left_building_menu.transform.localPosition = Vector2.MoveTowards(left_building_menu.transform.localPosition, new Vector2(left_destination, left_building_menu.transform.localPosition.y), speed * Time.deltaTime);
            }
        }

        // Hide right the panel
        if (right_destination > 0.0f)
        {
            if (right_building_menu.localPosition.x < right_destination)
            {
                right_building_menu.localPosition = Vector2.MoveTowards(right_building_menu.localPosition, new Vector2(right_destination, right_building_menu.localPosition.y), speed * Time.deltaTime);
            }
        }
        else if (right_destination == 0.0f)
        {
            if (right_building_menu.transform.localPosition.x > right_destination)
            {
                right_building_menu.transform.localPosition = Vector2.MoveTowards(right_building_menu.transform.localPosition, new Vector2(right_destination, right_building_menu.transform.localPosition.y), speed * Time.deltaTime);
            }
        }
    }

    public void ToggleLeftBuildingSelection()
    {
        left_destination = left_destination < 0.0f ? 0.0f : -left_building_menu.sizeDelta.x;
    }

    public void ToggleRightBuildingSelection()
    {
        right_destination = right_destination > 0.0f ? 0.0f : right_building_menu.sizeDelta.x;
    }

    void GetMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.transform.tag == "LeftBuilding")
                {
                    ToggleLeftBuildingSelection();
                }
                else if (hit.transform.tag == "RightBuilding")
                {
                    ToggleRightBuildingSelection();
                }
            }
        }
    }
}
