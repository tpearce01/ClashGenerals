using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceController : MonoBehaviour
{
    public static ResourceController master;    //Static reference to this script
    [SerializeField] Slider resourceBar;        //Slider to visually represent resources
    public float regenValue;

    void Awake()
    {
        master = this;
    }

    /// <summary>
    /// Modify the value field of resourceBar by adding
    /// </summary>
    /// <param name="value"></param>
    public void Modify(float value)
    {
        resourceBar.value += value;
    }

    void Update()
    {
        Modify(regenValue * Time.deltaTime);
    }

    public float GetValue()
    {
        return resourceBar.value;
    }
}
