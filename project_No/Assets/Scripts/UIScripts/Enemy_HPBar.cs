using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Enemy_HPBar : MonoBehaviour
{
    IHealth health;
    Slider healthSlider;
    TextMeshProUGUI enemyName;
    Enemy enmey;

    private void Start()
    {
        health = GetComponentInParent<IHealth>();
        healthSlider = GetComponent<Slider>();
        enemyName = transform.Find("EnemyNameText").GetComponent<TextMeshProUGUI>();
        enmey = GameManager.Inst.enemyMonster;
    }
    
    private void Update()
    {
        health.onHPChange += SetHP_Value;
        healthSlider.value = health.HP / health.MaxHP;
        enemyName.text = $"{enmey.enemyName}";
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
