using RoR2;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R2API.ScriptableObjects;
using Moonstorm;

namespace EntityStates.Nuke.Weapon
{
    public class FireFart : BaseNukeWeaponFireState
    {
        public static SerializableDamageColor damageColor;
        public static float extraDamageCoefficient;
        public static float baseForce;
        public static float baseRadius;
        public static float procCoefficient;
        public static float baseUpwardVelocity;
        public static float maxUpwardVelocity;
        public static Vector3 bonusForce;

        private BlastAttack _blastAttack;
        public override void OnEnter()
        {
            base.OnEnter();
            if(isAuthority)
            {
                _blastAttack = new BlastAttack
                {
                    attacker = gameObject,
                    inflictor = gameObject,
                    attackerFiltering = AttackerFiltering.NeverHitSelf,
                    baseDamage = damageStat * Charge * extraDamageCoefficient,
                    baseForce = baseForce * Charge,
                    radius = baseRadius * Charge,
                    bonusForce = bonusForce * Charge,
                    procCoefficient = procCoefficient,
                    teamIndex = teamComponent.AsValidOrNull()?.teamIndex ?? TeamIndex.None,
                    falloffModel = BlastAttack.FalloffModel.Linear,
                    damageType = DamageType.Stun1s,
                    position = characterBody.footPosition,
                    canRejectForce = false,
                    crit = RollCrit(),
                    damageColorIndex = damageColor.DamageColorIndex,
                };
                _blastAttack.Fire();

                if(!isGrounded)
                {
                    Vector3 velocity = characterMotor.velocity;
                    float yVelocity = baseUpwardVelocity * Charge;
                    velocity.y = Mathf.Min(yVelocity, maxUpwardVelocity);
                    characterMotor.velocity = velocity;
                }
            }
        }
    }
}
