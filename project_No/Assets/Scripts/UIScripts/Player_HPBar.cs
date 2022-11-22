using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Player_HPBar : MonoBehaviour
{
    IHealth health;
    Slider healthSlider;
    TextMeshProUGUI healthText;
    
    private void Start()
    {
        health = GameManager.Inst.MainPlayer.GetComponent<IHealth>();        
        healthSlider = GetComponent<Slider>();
        healthText = transform.Find("HealthText").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        health.onHPChange += SetHP_Value;
        healthSlider.value = health.HP / health.MaxHP;    
        healthText.text = $"{(int)health.HP} / {health.MaxHP}";
    }    

    private void SetHP_Value()
    {
        if(health != null)
        {
            float ratio = health.HP / health.MaxHP;
            healthSlider.value = ratio;            
        }        
    }    
}
