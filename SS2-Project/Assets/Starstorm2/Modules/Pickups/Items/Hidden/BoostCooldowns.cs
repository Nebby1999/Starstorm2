﻿using R2API;
using RoR2;
using RoR2.Items;
using UnityEngine;
using System;
namespace Moonstorm.Starstorm2.Items
{

    //skills recharge x% faster
    // 100 stacks = 50% cdr
    // 200 stacks = 67% cdr
    public sealed class BoostCooldowns : ItemBase
    {
        public override ItemDef ItemDef { get; } = SS2Assets.LoadAsset<ItemDef>("BoostCooldowns", SS2Bundle.Items);

        public override void Initialize()
        {
            RecalculateStatsAPI.GetStatCoefficients += AddCooldownReduction;
        }

        private void AddCooldownReduction(CharacterBody sender, RecalculateStatsAPI.StatHookEventArgs args)
        {
            float itemCount = sender.inventory ? sender.inventory.GetItemCount(ItemDef) : 0;
            if (itemCount > 0)
            {
                args.cooldownMultAdd -= Util.ConvertAmplificationPercentageIntoReductionPercentage(itemCount) / 100f;
            }
        }
    }
}
