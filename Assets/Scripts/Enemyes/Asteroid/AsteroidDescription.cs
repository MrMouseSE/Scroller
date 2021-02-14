using UnityEngine;

namespace Enemyes.Asteroid
{
    [CreateAssetMenu(fileName = "AsteroidDescription", menuName = "ScriptableObjects/AsteroidDescription", order = 1)]
    public class AsteroidDescription : EnemyDescription
    {
        public Vector2 AngularSpeed;
        public Vector2 Size;
    }
}