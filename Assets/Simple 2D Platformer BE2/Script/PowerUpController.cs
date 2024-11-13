using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    private PowerUp myPowerUp;
    private void Start()
    {
        myPowerUp = GetComponent<PowerUp>();
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Player"))
        {
            Player player = hit.GetComponent<Player>();
            
            if (myPowerUp == null || player == null) return;

            myPowerUp.ApplyPowerUp(player);
            Destroy(this.gameObject);
        }
    }
}
