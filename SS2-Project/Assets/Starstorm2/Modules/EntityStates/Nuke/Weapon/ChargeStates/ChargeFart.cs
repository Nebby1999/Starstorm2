using RoR2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntityStates.Nuke.Weapon
{
    public class ChargeFart : BaseNukeWeaponChargeState
    {
        public static float lookThreshold;

        private Ray aimRay;
        public override ref InputBankTest.ButtonState TiedBankButton => ref inputBank.skill2;

        public override BaseNukeWeaponFireState GetFireState()
        {
            aimRay = GetAimRay();
            var normalizedDirection = aimRay.direction.normalized;

            bool cratering = normalizedDirection.y <= lookThreshold && !characterMotor.isGrounded;

            if(cratering)
            {
                return new FireCraterFart();
            }
            return new FireFart();
        }
    }
}