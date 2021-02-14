using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemyes
{
    [CreateAssetMenu(fileName = "EnemyDescription", menuName = "ScriptableObjects/EnemyDescription", order = 1)]
    public class EnemyDescription : ScriptableObject
    {
        public EnemyType Type;
        public List<Mesh> Meshes;
        public GameObject GO;
        public Vector2 Hitpoints;
        public float SpawnRate;
        public float DiePosX;
        
        [Space]
        public SpawnRectangle[] SpawnRectangles;

        [Space] public GameObject DestroyFX;
        
        [Space]
        public Vector2 Speed;

        public float GetSpawnTime()
        {
            return 1 / SpawnRate;
        }

    }
    [Serializable]
    public struct SpawnRectangle
    {
        public Vector3 PointFrom;
        public Vector3 PointTo;
    }
}