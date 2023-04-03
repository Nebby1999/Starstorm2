using RoR2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Moonstorm.Starstorm2.Components
{
    public class NukeSelfDamageController : MonoBehaviour
    {
        [SerializeField] private BuffDef selfDamageBuffDef;
        [SerializeField, Tooltip("The minimum coefficient that's taken as damage when overcharging.")] private float minMaxHealthCoefficient;
        [SerializeField, Tooltip("The maximum coefficientt that's taken as damage when overcharging.")] private float maxHealthCoefficient;

    }
}