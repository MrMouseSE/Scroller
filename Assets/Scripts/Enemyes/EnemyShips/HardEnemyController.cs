using UnityEngine;

namespace Enemyes.EnemyShips
{
    public class HardEnemyController : SimpleEnemyController
    {
        private bool _fallow;
        public override EnemyState UpdateState(Transform playerTransform)
        {
            if (transform.position.x < -70 || _fallow)
                FallowPlayer(playerTransform);
            return base.UpdateState(playerTransform);
        }

        private void FallowPlayer(Transform playerTransform)
        {
            _fallow = true;
            EnemyShipContainer.Speed = 0f;
            var directionVector = playerTransform.position - transform.position;
            var distance = Vector3.Magnitude(directionVector);
            transform.rotation = Quaternion.Lerp(transform.rotation, 
                Quaternion.LookRotation( playerTransform.position - transform.position, Vector3.up),Time.deltaTime);
            var newPosition = playerTransform.position;
            newPosition.x -= 50f;
            transform.position = Vector3.Lerp(transform.position,newPosition, Time.deltaTime);
        }
    }
}