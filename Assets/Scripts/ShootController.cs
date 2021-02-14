using System.Collections;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private ShootContainer _container;

    private void Start()
    {
        StartCoroutine(MoveForward());
    }

    private IEnumerator MoveForward()
    {
        while (_container.LifeTime > 0)
        {
            transform.Translate(Vector3.right * _container.ShootSpeed);
            _container.LifeTime -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}