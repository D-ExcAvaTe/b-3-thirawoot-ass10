using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textHealth, textSpeed, textSpeedDuration, textStrength;
    [SerializeField] private Slider sliderSpeedDuration;
    
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
        Debug.Log($"<color=#80FF88>+Buff {health} +{newHealth} Health</color>");
        health += newHealth;
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


        sliderSpeedDuration.maxValue = speedBoostDuration;
    }

    public void UpdateSpeedBoostTimer()
    {
        if (!isSpeedBoostActive) return;

        if (speedBoostTimer > 0)
        {
            speedBoostTimer -= Time.deltaTime;
            
            Debug.Log("Speed boost Active!!");
            UpdateTextSpeed();
            //Debug.Log($"Speed boost {speedBoostTimer.ToString("0#.00")} sec left");
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
    private void UpdateTextStrength() => textStrength.text = strength.ToString();

    private void UpdateTextSpeed()
    {
        textSpeed.text = speed.ToString();
        textSpeedDuration.text = $"{speedBoostTimer.ToString("0#.00")} sec";
        sliderSpeedDuration.value = speedBoostTimer;
    }

}
