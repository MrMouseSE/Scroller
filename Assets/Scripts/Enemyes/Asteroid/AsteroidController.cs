using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemyes.Asteroid
{
    public class AsteroidController : EnemyController, IEnemyObject
    {
        public AsteroidContainer AsteroidContainer
        {
            get => _asteroidContainer;
            set => _asteroidContainer = value;
        }
        private AsteroidContainer _asteroidContainer;

        private Vector3 _rotationAxis;

        private EnemyState _dieOrOut = 0;

        private void Start()
        {
            _rotationAxis = Random.insideUnitSphere;
            transform.rotation = Quaternion.LookRotation(Vector3.left);
            transform.Rotate(Vector3.up,Random.Range(-45f,45f));
            _asteroidContainer.MeshTransform.localScale = new Vector3(_asteroidContainer.Size,_asteroidContainer.Size, _asteroidContainer.Size);
            _asteroidContainer.Collider.radius *= _asteroidContainer.Size;
            HitPoints = _asteroidContainer.Hitpoints;
        }
        
        public EnemyState UpdateState(Transform playerTransform)
        {
            SetNewPosition();
            if (transform.position.x < _asteroidContainer.DiePosX)
                _dieOrOut = EnemyState.Out;
            if (HitPoints<=0)
            {
                _dieOrOut = EnemyState.Die;
            }
            
            return _dieOrOut;
        }

        private void SetNewPosition()
        {
            float time = Time.deltaTime;
            transform.Translate(Vector3.forward * (_asteroidContainer.Speed * time));
            _asteroidContainer.MeshFilter.transform.Rotate(_rotationAxis,_asteroidContainer.AngularSpeed * time);
        }

        public override void Destroy()
        {
            Destroy(Instantiate(_asteroidContainer.DestroyFX,transform.position,Quaternion.identity),5f);
            base.Destroy();
        }
    }
}