using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStamina
{
    float Stamina { get; set; }

    float MaxStamina { get; }

    System.Action onStaminaChange { get; set; }
}
