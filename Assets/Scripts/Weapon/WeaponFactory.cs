using UnityEngine;

namespace Weapon
{
    public class WeaponFactory
    {
        public static void CreateShoot(WeaponDescription description, Transform transform)
        {
            switch (description.Type)
            {
                case WeaponType.Laser:
                    CreateLaser(description, transform);
                    break;
                default:
                    break;
            }
        }

        private static GameObject CreateLaser(WeaponDescription description, Transform transform)
        {
            GameObject go = Object.Instantiate(description.ShootObject, transform.position, transform.rotation);
            var shootContainer = go.GetComponent<ShootContainer>();
            shootContainer.ShootSpeed = description.Speed;
            shootContainer.LifeTime = description.LifeTime;
            shootContainer.Damage = description.Damage;
            Object.Instantiate(description.ViewFX, go.transform);
            
            return go;
        }
    }
}