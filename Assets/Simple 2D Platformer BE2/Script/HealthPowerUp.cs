using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : PowerUp
{
    [SerializeField] private int healthIncrease;

    public override void ApplyPowerUp(Player player)
    {
        player.PowerUp(healthIncrease);
    }
}
