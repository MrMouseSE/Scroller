using UnityEngine;

namespace Weapon
{
    [CreateAssetMenu(fileName = "WeaponDescription", menuName = "ScriptableObjects/WeaponDescription", order = 10)]
    public class WeaponDescription : ScriptableObject
    {
        public WeaponType Type;
        public float LifeTime;
        public float Speed;
        public GameObject ShootObject;
        public GameObject ViewFX;
        public float Damage;
        public float FireRate;

        public float GetWeaponCooldown()
        {
            return 1 / FireRate;
        }
    }

    public enum WeaponType
    {
        Laser = 0
    }
}