using UnityEngine;

namespace Enemyes
{
    public class EnemyContainer : MonoBehaviour
    {
        public EnemyType Type;
        public int Hitpoints;
        public Transform MeshTransform;
        public MeshFilter MeshFilter;
        public MeshRenderer MeshRenderer;
        public SphereCollider Collider;
        public float Speed;
        public float DiePosX = - 100;
        public GameObject DestroyFX;

    }

    public enum EnemyType
    {
        Asteroid,
        SimpleShip,
        MediumShip,
        HardShip
    }
}