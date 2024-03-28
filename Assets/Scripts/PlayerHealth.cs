using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] RectTransform rectValue;
    [SerializeField] private float healthValue;
    [SerializeField] private GameObject gameplayUI;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private AmmoController ammoController;
    [SerializeField] private CameraRotation cameraRotation;
    private float _maxValue;
    private void Start()
    {
        _maxValue = healthValue;
        DrawHealthBar();
    }
    public void DealDamage(float damage)
    {
        healthValue -= damage;
        if (healthValue <= 0)
        {
            PlayerIsDead();
        }
        DrawHealthBar();
    }
    public void AddHealth(float percentage)
    {
       
        healthValue += percentage;
        healthValue = Mathf.Clamp(healthValue, 0, _maxValue);
        DrawHealthBar();
        
    }

    private void DrawHealthBar()
    {
        rectValue.anchorMax = new Vector2(healthValue / _maxValue, 1);
    }
    private void PlayerIsDead()
    {
        gameplayUI.SetActive(false);
        gameOverScreen.SetActive(true);
        playerController.enabled = false;
        ammoController.enabled = false;
        cameraRotation.enabled = false;
    }
} 
