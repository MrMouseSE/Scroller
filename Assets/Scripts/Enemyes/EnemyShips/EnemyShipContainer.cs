using System.Collections.Generic;
using UnityEngine;
using Weapon;

namespace Enemyes.EnemyShips
{
    public class EnemyShipContainer : EnemyContainer
    {
        public List<Transform> WeaponPoints;
        public WeaponDescription WeaponDescription;
        public Transform Rotator;
    }
}