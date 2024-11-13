using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textHealth, textSpeed, textStrength;
    
    private int health = 10;
    private float strength = 10f;
    private float speed = 5f;
    
    public int Health
    {
        get => health;
        set => health = value;
    }
    public float Strength
    {
        get => strength;
        set => strength = value;
    }
    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    private float originalSpeed;
    private float speedBoostDuration;
    private float speedBoostTimer;
    private bool isSpeedBoostActive;

    private void Start()
    {
        originalSpeed = speed;
        
        UpdateTextHealth();
        UpdateTextSpeed();
        UpdateTextStrength();
    }

    private void Update()
    {
        UpdateSpeedBoostTimer();
    }

    public void PowerUp(int newHealth)
    {
        health += newHealth;
        Debug.Log($"<color=#80FF88>+Buff {health} Health</color>");
        UpdateTextHealth();
    }

    public void PowerUp(float multiplier)
    {
        strength *= multiplier;
        Debug.Log($"<<color=#FF9980>+Buff {strength} Strength</color>");
        UpdateTextStrength();

    }

    public void PowerUp(float miltiplier, float duration)
    {
        if (isSpeedBoostActive) return;

        speed *= miltiplier;
        isSpeedBoostActive = true;
        speedBoostDuration = duration;
        speedBoostTimer = duration;

        Debug.Log($"<color=#DDFF80>+Buff {speed} Speed for {duration.ToString("0#.00")} seconds</color>");
        UpdateTextSpeed();
    }

    public void UpdateSpeedBoostTimer()
    {
        if (!isSpeedBoostActive) return;

        if (speedBoostTimer > 0)
        {
            speedBoostTimer -= Time.deltaTime;
            Debug.Log($"Speed boost {speedBoostTimer.ToString("0#.00")} sec left");
        }
        else
        {
            speed = originalSpeed;
            isSpeedBoostActive = false;
            
            Debug.Log("Speed boost effect expired");
            UpdateTextSpeed();
        }
    }

    private void UpdateTextHealth() => textHealth.text = health.ToString();
    private void UpdateTextSpeed() => textSpeed.text = speed.ToString();
    private void UpdateTextStrength() => textStrength.text = strength.ToString();
}
