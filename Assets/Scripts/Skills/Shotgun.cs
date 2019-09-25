using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public PlayerPlatformerController player;
    public DirectionalCharge charger;

    private bool shotgunRequiresCharge = true;
    private (float min, float max) shotgunDamageRange = (50f, 100f);
    private float shotgunKnockbackMultiplier = 5f;

    public float ShootShotgun()
    {
        float damageAmount = shotgunDamageRange.min;

        if (shotgunRequiresCharge)
        {
            charger.StartCharge();
        }

        while (charger.IsSkillCharging)
        {

        }

        player.m_rigidbody2D.AddForce(new Vector2(0f, shotgunKnockbackMultiplier));

        return damageAmount *= charger.EndCharge();
    }
}
