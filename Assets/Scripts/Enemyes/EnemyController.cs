using UnityEngine;

namespace Enemyes
{
    public class EnemyController : MonoBehaviour
    {
        public enum EnemyState
        {
            None = 0,
            Die = 1,
            Out = 2
        }

        public int HitPoints; 

        public void OnTriggerEnter(Collider other)
        {
            HitPoints--;
            if (other.gameObject.layer == LayerMask.NameToLayer("Bullets"))
            {
                Destroy(other);
            }
        }
        
        public virtual void Destroy()
        {
            Destroy(gameObject);
        }
    }
}