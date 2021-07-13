using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DirtyDand.Globals.GlobalVariables;

namespace DirtyDand.Classes
{
    public class Weapon : Item
    {
        int damage;
        DamageType damageType;
        List<WeaponProperty> properties;
        bool magical;
        int[] range;


        public Weapon(int damage, DamageType damageType, bool magical, string name, string discription, int[] range = null, int value = 0): base(name, discription, value)
        {
            this.damage = damage;
            this.damageType = damageType;
            this.magical = magical;
            this.range = range;
        }

    
    }
}
