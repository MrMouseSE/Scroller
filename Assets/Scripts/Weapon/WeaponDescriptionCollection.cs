using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    [CreateAssetMenu(fileName = "WeaponDescriptionsCollection", menuName = "ScriptableObjects/WeaponDescriptionsCollection", order = 10)]
    public class WeaponDescriptionCollection : ScriptableObject
    {
        public List<WeaponDescription> WeaponDescriptions;
        
        public WeaponDescription GetEnemyDescriptionByType(WeaponType type)
        {
            return WeaponDescriptions.Find(x => x.Type == type);
        }
    }
}