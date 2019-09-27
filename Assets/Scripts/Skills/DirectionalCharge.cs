using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public abstract class DirectionalCharge : MonoBehaviour
{
    [HideInInspector] public bool IsSkillCharging { get; set; }

    #region Fields

    public PlayerPlatformerController _player;
    public Slider _chargeBar;    

    //Modifiable Fields: 
    private long _chargeTimeoutInMs = 1000;
    private float chargeSpeedMultiplier = 1f;
    private (float min, float max) chargeLevelBoundaries = (.50f, 1.1f); // affects range/damage dealt by percentage for all charge abilities

    // Unmodifiable Fields: 
    private Stopwatch _chargeTimeoutTimer;
    private float _chargeLevel { get; set; }


    #endregion

    private void Start()
    {
        _chargeBar.minValue = chargeLevelBoundaries.min;
        _chargeBar.maxValue = chargeLevelBoundaries.max;

    }

    private void FixedUpdate()
    {
        MoveAimerToPlayer();
        faceAimerToMousePosition();
        ChargeController();
    }

    public void StartCharge()
    {
        _chargeTimeoutTimer.Start();
        IsSkillCharging = true;
    }

    public (float, Vector2) EndCharge()
    {
        float chargeValue = _chargeBar.value;
        Vector2 aimDirection = faceAimerToMousePosition();
        _chargeTimeoutTimer.Stop();
        _chargeTimeoutTimer.Reset();
        IsSkillCharging = false;
        return (chargeValue, aimDirection);
    }

    #region Aimer

    private void MoveAimerToPlayer()
    {
        _chargeBar.transform.position = _player.transform.position;
    }

    private Vector2 faceAimerToMousePosition()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y);

        _chargeBar.transform.up = direction;
        _chargeBar.transform.Rotate(Vector2.up, 1f);

        return direction;
    }

    #endregion

    #region Charger

    private void ChargeController()
    {
        if (IsSkillCharging && (_chargeTimeoutTimer.ElapsedMilliseconds < _chargeTimeoutInMs))
        {
            // i think slowing time here would be best.........
            _chargeBar.value = _chargeBar.value += Time.unscaledDeltaTime * chargeSpeedMultiplier;
        }

        if (!IsSkillCharging || _chargeTimeoutTimer.ElapsedMilliseconds > _chargeTimeoutInMs)
        {
            ResetCharge();
        }
    }

    private void ResetCharge()
    {
        _chargeLevel = _chargeBar.value;
        IsSkillCharging = false;
        _chargeBar.value = _chargeBar.minValue;
    }

    #endregion









}
