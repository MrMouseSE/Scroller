using System.Collections.Generic;
using UnityEngine;

namespace Enemyes
{
    public class EnemyOverlord : MonoBehaviour
    {
        [SerializeField] private EnemyDescriptionCollection _enemyDescriptionCollectionDescription;
        [SerializeField] private Transform _player;
        
        private List<IEnemyObject> _enemyes;
        private List<EnemySpawnCounter> _counters;
        private List<IEnemyObject> _garbage;
    
        private void Start()
        {
            _enemyes = new List<IEnemyObject>();
            _garbage = new List<IEnemyObject>();
            _counters = new List<EnemySpawnCounter>();
            CreateCounters();
        }

        private void CreateCounters()
        {
            foreach (var description in _enemyDescriptionCollectionDescription.EnemyDescriptions)
            {
                var counter = new EnemySpawnCounter(description.Type, description.GetSpawnTime(),
                    description.GetSpawnTime());
                _counters.Add(counter);
            }
        }

        void Update()
        {
            foreach (var enemy in _enemyes)
            {
                switch (enemy.UpdateState(_player))
                {
                    case EnemyController.EnemyState.None:
                        continue;
                    case EnemyController.EnemyState.Out:
                        DestroyEnemyAndGarbage(enemy);
                        break;
                    case EnemyController.EnemyState.Die:
                        DestroyEnemyAndGarbage(enemy);
                        break;
                }
            }

            ClearEnemyList();
            DecreaseAllCount();
        }

        private void DestroyEnemyAndGarbage(IEnemyObject enemy)
        {
            enemy.Destroy();
            _garbage.Add(enemy);
        }

        private void ClearEnemyList()
        {
            foreach (var garbage in _garbage)
            {
                _enemyes.Remove(garbage);
            }
        }

        private void DecreaseAllCount()
        {
            foreach (var count in _counters)
            {
                count.CurrentTime -= Time.deltaTime;
                if (count.CurrentTime < 0)
                {
                    SpawnNewEnemy(count.Type);
                    count.CurrentTime = count.ReferenceTime;
                }
            }
        }

        private void SpawnNewEnemy(EnemyType type)
        {
            CreateNewEnemy(_enemyDescriptionCollectionDescription.GetEnemyDescriptionByType(type));
        }

        private void CreateNewEnemy(EnemyDescription enemyDescription)
        {
            var enemy = EnemyFactory.CreateNewEnemy(enemyDescription);
            _enemyes.Add(enemy);
        }
    }
}