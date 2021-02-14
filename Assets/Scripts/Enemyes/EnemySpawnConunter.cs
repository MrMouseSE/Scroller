namespace Enemyes
{
    public class EnemySpawnCounter
    {
        public EnemyType Type;
        public float CurrentTime;
        public float ReferenceTime;

        public EnemySpawnCounter(EnemyType type, float currentTime, float referenceTime)
        {
            Type = type;
            CurrentTime = currentTime;
            ReferenceTime = referenceTime;
        }
    }
}