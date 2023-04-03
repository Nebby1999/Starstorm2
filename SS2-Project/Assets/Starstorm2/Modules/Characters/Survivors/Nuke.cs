using RoR2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Moonstorm.Starstorm2.Survivors
{
    public class Nuke : SurvivorBase
    {
        public override SurvivorDef SurvivorDef => SS2Assets.LoadAsset<SurvivorDef>("Nuke", SS2Bundle.Indev);

        public override GameObject BodyPrefab => SS2Assets.LoadAsset<GameObject>("NukeBody", SS2Bundle.Indev);

        public override GameObject MasterPrefab => null;

        public override void ModifyPrefab()
        {
            base.ModifyPrefab();

            var cb = BodyPrefab.GetComponent<CharacterBody>();
            cb.preferredPodPrefab = Resources.Load<GameObject>("Prefabs/NetworkedObjects/SurvivorPod");
            cb._defaultCrosshairPrefab = Resources.Load<GameObject>("Prefabs/Crosshair/StandardCrosshair");
            var ctp = BodyPrefab.GetComponent<CameraTargetParams>();
            ctp.cameraParams = Addressables.LoadAssetAsync<CharacterCameraParams>("RoR2/Base/Commando/ccpCommando.asset").WaitForCompletion();

            var sludge = SS2Assets.LoadAsset<GameObject>("NukeSludgeProjectile", SS2Bundle.Indev).AddComponent<R2API.DamageAPI.ModdedDamageTypeHolderComponent>();
        }
    }
}