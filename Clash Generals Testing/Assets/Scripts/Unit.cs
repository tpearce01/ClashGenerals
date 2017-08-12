using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{

    public int health;
    public int maxHealth;

    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image healthSliderFill;

    [SerializeField] private Color lowlHP;
    [SerializeField] private Color mediumHP;
    [SerializeField] private Color fullHP;

    void OnEnable()
    {
        //healthSlider.enabled = false; //Hide health bar when it is guaranteed to be full
        health = maxHealth;
        healthSlider.value = 1 /*(float) health/maxHealth*/;
        SetColor(1 /*healthSlider.value*/);
    }

    public void ModifyHealth(int value)
    {
        //healthSlider.enabled = true;  //Show health bar once health has been modified to reflect changes, if any
        health += value;
        Mathf.Clamp(health, 0, maxHealth);

        healthSlider.value = (float) health/maxHealth;
        SetColor(healthSlider.value);
    }

    void SetColor(float value) {
        if (value > .5f) {
            healthSliderFill.color = Color.Lerp(mediumHP, fullHP, (value - .5f) / .5f);
        }
        else {
            healthSliderFill.color = Color.Lerp(lowlHP, mediumHP, value / .5f);
        }
    }

    protected virtual void Kill() {
        Destroy(gameObject);
    }
}
