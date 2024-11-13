using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : PowerUp
{
    [SerializeField] private float speedMultiplier;
    [SerializeField] private float speedDuration;
    
    public override void ApplyPowerUp(Player player)
    {
        player.PowerUp(speedMultiplier, speedDuration);
    }
}
