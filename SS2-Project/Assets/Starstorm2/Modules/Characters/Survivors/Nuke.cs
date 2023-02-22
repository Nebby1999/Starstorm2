using RoR2;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moonstorm.Starstorm2.Survivors
{
    public class Nuke : SurvivorBase
    {
        public override SurvivorDef SurvivorDef => SS2Assets.LoadAsset<SurvivorDef>("Nuke", SS2Bundle.Indev);

        public override GameObject BodyPrefab => SS2Assets.LoadAsset<GameObject>("NukeBody", SS2Bundle.Indev);

        public override GameObject MasterPrefab => null;
    }
}