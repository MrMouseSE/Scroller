using Enemyes.Asteroid;
using Enemyes.EnemyShips;
using UnityEngine;

namespace Enemyes
{
    public class EnemyFactory
    {
        public static IEnemyObject CreateNewEnemy(EnemyDescription enemyDescription)
        {
            switch (enemyDescription.Type)
            {
                case EnemyType.Asteroid:
                    return CreateAsteroid(enemyDescription as AsteroidDescription);
                case EnemyType.SimpleShip:
                    return CreateEnemyShip(enemyDescription as ShipEnemyDescription);
                case EnemyType.MediumShip:
                    return CreateEnemyShip(enemyDescription as ShipEnemyDescription);
                case EnemyType.HardShip:
                    return CreateEnemyShip(enemyDescription as ShipEnemyDescription);
                default:
                    return null;
            }
        }
        
        private static IEnemyObject CreateAsteroid(AsteroidDescription asteroidDescription)
        {
            Vector3 position = GetRandomPointToSpawn(asteroidDescription);
            GameObject asteroid = Object.Instantiate(asteroidDescription.GO, position, Quaternion.identity);
            
            var asteroidContainer = asteroid.GetComponent<AsteroidContainer>();
            SetContainerSettings(asteroidContainer, asteroidDescription);
            asteroidContainer.Size = GetRandomFloatFromVector(asteroidDescription.Size);
            asteroidContainer.Speed = GetRandomFloatFromVector(asteroidDescription.Speed);
            asteroidContainer.AngularSpeed = GetRandomFloatFromVector(asteroidDescription.AngularSpeed);
            asteroidContainer.DestroyFX = asteroidDescription.DestroyFX;
            asteroidContainer.DiePosX = asteroidDescription.DiePosX;

            var asteroidController = asteroid.AddComponent<AsteroidController>();
            asteroidController.AsteroidContainer = asteroidContainer;
            
            return asteroidController;
        }
        
        private static IEnemyObject CreateEnemyShip(ShipEnemyDescription enemyDescription)
        {
            Vector3 position = GetRandomPointToSpawn(enemyDescription);
            GameObject enemy = Object.Instantiate(enemyDescription.GO, position, Quaternion.identity);
            
            var enemyContainer = enemy.GetComponent<EnemyShipContainer>();
            SetContainerSettings(enemyContainer, enemyDescription);
            enemyContainer.Speed = GetRandomFloatFromVector(enemyDescription.Speed);
            enemyContainer.DestroyFX = enemyDescription.DestroyFX;
            enemyContainer.DiePosX = enemyDescription.DiePosX;
            enemyContainer.WeaponDescription = enemyDescription.WeaponDescription;

            enemyContainer.MeshRenderer.material = enemyDescription.EnemyShipMaterial;
            
            switch (enemyDescription.Type)
            {
                case EnemyType.MediumShip:
                    return SetMediumEnemyController(enemy, enemyContainer);
                case EnemyType.HardShip:
                    return SetHardEnemyController(enemy, enemyContainer);
                case EnemyType.SimpleShip:
                    return SetSimpleEnemyController(enemy, enemyContainer);
            }
            return null;
        }

        private static SimpleEnemyController SetSimpleEnemyController(GameObject enemy, EnemyShipContainer container)
        {
            var enemyController = enemy.AddComponent<SimpleEnemyController>();
            enemyController.EnemyShipContainer = container;
            return enemyController;
        }
        
        private static MediumEnemyController SetMediumEnemyController(GameObject enemy, EnemyShipContainer container)
        {
            var enemyController = enemy.AddComponent<MediumEnemyController>();
            enemyController.EnemyShipContainer = container;
            return enemyController;
        }
        
        private static HardEnemyController SetHardEnemyController(GameObject enemy, EnemyShipContainer container)
        {
            var enemyController = enemy.AddComponent<HardEnemyController>();
            enemyController.EnemyShipContainer = container;
            return enemyController;
        }

        private static void SetContainerSettings(EnemyContainer enemyContainer, EnemyDescription enemyDescription)
        {
            enemyContainer.MeshFilter.mesh = GetRandomMeshFromList(enemyDescription);
            enemyContainer.Hitpoints = GetRandomIntFromVector(enemyDescription.Hitpoints);
        }

        private static Vector3 GetRandomPointToSpawn(EnemyDescription enemyDescription)
        {
            int rectangleIndex = Random.Range(0, enemyDescription.SpawnRectangles.Length);
            var spawnRectangle = enemyDescription.SpawnRectangles[rectangleIndex];
            float xPos = Random.Range(spawnRectangle.PointFrom.x, spawnRectangle.PointTo.x);
            float yPos = Random.Range(spawnRectangle.PointFrom.y, spawnRectangle.PointTo.y);
            float zPos = Random.Range(spawnRectangle.PointFrom.z, spawnRectangle.PointTo.z);
            return new Vector3(xPos,yPos,zPos);
        }

        private static Mesh GetRandomMeshFromList(EnemyDescription enemyDescription)
        {
            int meshIndex = Random.Range(0, enemyDescription.Meshes.Capacity);
            Mesh mesh = enemyDescription.Meshes[meshIndex];
            return mesh;
        }

        private static int GetRandomIntFromVector(Vector2 vector)
        {
            return (int) Random.Range(vector.x, vector.y);
        }

        private static float GetRandomFloatFromVector(Vector2 vector)
        {
            return Random.Range(vector.x, vector.y);
        }
    }
}