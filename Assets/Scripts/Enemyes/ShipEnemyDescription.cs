using UnityEngine;
using Weapon;

namespace Enemyes
{
    [CreateAssetMenu(fileName = "ShipEnemyDescription", menuName = "ScriptableObjects/ShipEnemyDescription", order = 1)]
    public class ShipEnemyDescription : EnemyDescription
    {
        [Space]
        public WeaponDescription WeaponDescription;

        [Space]
        public Material EnemyShipMaterial;
    }
}