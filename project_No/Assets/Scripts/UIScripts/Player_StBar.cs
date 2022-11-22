using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_StBar : MonoBehaviour
{
    IStamina stamina;
    Slider stSlider;

    private void Start()
    {
        stamina = GameManager.Inst.MainPlayer.GetComponent<IStamina>();
        stSlider = GetComponent<Slider>();        
    }

    private void Update()
    {
        stamina.onStaminaChange += SetStamina_Value;
        stSlider.value = stamina.Stamina / stamina.MaxStamina;        
    }

    private void SetStamina_Value()
    {
        if (stamina != null)
        {
            float stratio = stamina.Stamina / stamina.MaxStamina;
            stSlider.value = stratio;            
        }
        
    }
}
