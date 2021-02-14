using UnityEngine;

namespace Enemyes
{
    public interface IEnemyObject
    {
        EnemyController.EnemyState UpdateState(Transform playerTransform);
        void Destroy();
    }
}