using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using RoR2;
using RoR2.Projectile;
using R2API.ScriptableObjects;

namespace EntityStates.Nuke.Weapon
{
    public class FireSludge : BaseNukeWeaponFireState
    {
        public static GameObject projectilePrefab;
        public static SerializableDamageColor damageColor;
        public static float force;
        [HideInInspector]
        public static GameObject muzzleFlashPrefab = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Croco/CrocoDiseaseImpactEffect.prefab").WaitForCompletion();

        public string chosenMuzzleString;
        public Transform muzzleTransform;

        private Ray aimRay;
        public override void OnEnter()
        {
            base.OnEnter();
            aimRay = GetAimRay();
            if(muzzleFlashPrefab)
            {
                EffectManager.SimpleMuzzleFlash(muzzleFlashPrefab, gameObject, chosenMuzzleString, true);
            }

            FireProjectileInfo projectileInfo = new FireProjectileInfo
            {
                crit = RollCrit(),
                position = aimRay.origin,
                rotation = Util.QuaternionSafeLookRotation(aimRay.direction),
                owner = gameObject,
                projectilePrefab = projectilePrefab,
                damage = damageStat * Charge,
                damageColorIndex = damageColor.DamageColorIndex,
                force = force,
            };
            ProjectileManager.instance.FireProjectile(projectileInfo);
            outer.SetNextStateToMain();
        }
    }
}
