﻿using UnityEngine;
using RoR2;
using RoR2.Skills;
using UnityEngine.Networking;

namespace EntityStates.Knight
{
public class BannerSpecial : BaseState
{
    public static SkillDef buffedSkillRef;
    public static GameObject powerBuffWard;
    public static GameObject slowBuffWard;
            
    private GameObject powerBuffWardInstance;
    private GameObject slowBuffWardInstance;

    public override void OnEnter()
    {
        if (isAuthority)
        {
            Vector3 position = inputBank.aimOrigin - (inputBank.aimDirection);
            powerBuffWardInstance = UnityEngine.Object.Instantiate(powerBuffWard, position, Quaternion.identity);
            slowBuffWardInstance = UnityEngine.Object.Instantiate(slowBuffWard, position, Quaternion.identity);

            powerBuffWardInstance.GetComponent<TeamFilter>().teamIndex = characterBody.teamComponent.teamIndex;
            slowBuffWardInstance.GetComponent<TeamFilter>().teamIndex = characterBody.teamComponent.teamIndex;

            NetworkServer.Spawn(powerBuffWardInstance);
            NetworkServer.Spawn(slowBuffWardInstance);
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void OnExit()
    {
        outer.SetNextStateToMain();
        base.OnExit();
    }

    public override InterruptPriority GetMinimumInterruptPriority()
    {
        return InterruptPriority.PrioritySkill;
    }
}

}