using System.Collections.Generic;
using UnityEngine;

namespace Enemyes
{
    [CreateAssetMenu(fileName = "EnemyDescriptionsCollection", menuName = "ScriptableObjects/EnemyDescriptionsCollection", order = 1)]
    public class EnemyDescriptionCollection : ScriptableObject
    {
        public List<EnemyDescription> EnemyDescriptions;

        public EnemyDescription GetEnemyDescriptionByType(EnemyType type)
        {
            return EnemyDescriptions.Find(x => x.Type == type);
        }
    }
}