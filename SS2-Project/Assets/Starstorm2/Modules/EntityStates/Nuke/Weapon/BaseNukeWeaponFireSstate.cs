using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityStates.Nuke.Weapon
{
    public abstract class BaseNukeWeaponFireState : BaseSkillState
    {
        public float Charge { get; set; }
    }
}