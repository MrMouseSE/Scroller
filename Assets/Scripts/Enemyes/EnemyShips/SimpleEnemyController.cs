using System.Collections;
using UnityEngine;
using Weapon;

namespace Enemyes.EnemyShips
{
    public class SimpleEnemyController : EnemyController, IEnemyObject
    {
        public EnemyShipContainer EnemyShipContainer;
        private bool _readyToFire = true;

        private EnemyState _dieOrOut = 0;
        
        public virtual void Start()
        {
            transform.rotation = Quaternion.LookRotation(Vector3.left);
            HitPoints = EnemyShipContainer.Hitpoints;
        }
        
        public virtual EnemyState UpdateState(Transform playerTransform)
        {
            SetNewPosition();
            if (transform.position.x < EnemyShipContainer.DiePosX)
                _dieOrOut = EnemyState.Out;
            if (HitPoints<=0)
            {
                _dieOrOut = EnemyState.Die;
            }

            if (_readyToFire)
            {
                ShootForward();
            }
            
            return _dieOrOut;
        }

        private void ShootForward()
        {
            foreach (var weaponPoint in EnemyShipContainer.WeaponPoints)
            {
                WeaponFactory.CreateShoot(EnemyShipContainer.WeaponDescription, weaponPoint);
            }

            StartCoroutine(ReloadGuns());
        }
        
        private void SetNewPosition()
        {
            float time = Time.deltaTime;
            transform.Translate(Vector3.forward * (EnemyShipContainer.Speed * time));
        }

        private IEnumerator ReloadGuns()
        {
            _readyToFire = false;
            yield return new WaitForSeconds(EnemyShipContainer.WeaponDescription.GetWeaponCooldown());
            _readyToFire = true;
        }
        
        public override void Destroy()
        {
            Destroy(Instantiate(EnemyShipContainer.DestroyFX,transform.position,Quaternion.identity),5f);
            base.Destroy();
        }
    }
}