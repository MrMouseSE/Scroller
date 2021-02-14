using UnityEngine;

namespace Enemyes.EnemyShips
{
    public class MediumEnemyController : SimpleEnemyController, IEnemyObject
    {
        public override void Start()
        {
            EnemyShipContainer = GetComponent<EnemyShipContainer>(); 
            base.Start();
            transform.Rotate(Vector3.up,Random.Range(-45f,45f));
        }
        
        public override EnemyState UpdateState(Transform playerTransform)
        {
            RotateToTarget(playerTransform);
            return base.UpdateState(playerTransform);
        }

        private void RotateToTarget(Transform playerTransform)
        {
            var rotateTransform = EnemyShipContainer.Rotator;
            rotateTransform.rotation = Quaternion.LookRotation(playerTransform.position - rotateTransform.position, Vector3.up);
        }
    }
}