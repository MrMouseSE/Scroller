using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Weapon;

public class ShipController : MonoBehaviour
{
    [SerializeField] private ShipContainer _container;

    private int _rightShootHash;
    private int _leftShootHash;
    private bool _shootSide;
    private bool _readyToFireLeft = true;
    private bool _readyToFireRight = true;

    private WeaponDescription _weaponDescription;

    void Awake()
    {
        _rightShootHash = Animator.StringToHash(_container.RightShootTrigger);
        _leftShootHash = Animator.StringToHash(_container.LeftShootTrigger);

        ChangeWeapon(_container.CurrentWeapon);
    }

    void Update()
    {
        MoveAction();
        
        if (Input.GetMouseButton(0) && _readyToFireLeft)
            ShootActionLeftMouseButton(_shootSide);
        if (Input.GetMouseButtonDown(1) && _readyToFireRight)
            ShootActionRightMouseButton();

        if (_container.Hitpoints <= 0)
        {
            Destroy(Instantiate(_container.DestroyFX, transform.position, Quaternion.identity),5f);
            Destroy(gameObject);
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBullet") return;

        _container.Hitpoints--;
    }

    private void ChangeWeapon(WeaponType type)
    {
        _container.CurrentWeapon = type;
        _weaponDescription = _container.Weapon.GetEnemyDescriptionByType(_container.CurrentWeapon);
    }

    private void MoveAction()
    {
        var speedVec = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"));
        ChangeVectorValue(speedVec, _container.ShipSpeed);
    }

    private void ChangeVectorValue(Vector3 referenceVector, float speed)
    {
        var positionVector = transform.position;
        positionVector += referenceVector*speed;
        positionVector.z = Mathf.Clamp(positionVector.z ,-50f, 50f);
        positionVector.x = Mathf.Clamp(positionVector.x ,-80f, 80f);
        transform.position = positionVector;
    }

    private void ShootActionLeftMouseButton(bool rightShoot)
    {
        int trigger = rightShoot ? _rightShootHash : _leftShootHash;
        Transform shootTransform = rightShoot ? _container.RightShootPosition : _container.LeftShootPosition;
        SetAnimatorTrigger(trigger);
        InstantiateWeaponObject(shootTransform);
        _shootSide = !_shootSide;
        StartCoroutine(ReloadShootLeftMouseButton(_weaponDescription));
    }
    
    private void ShootActionRightMouseButton()
    {
        foreach (var shootTransform in _container.RightMouseButtonShootPositions)
        {
            InstantiateWeaponObject(shootTransform);
        }
        StartCoroutine(ReloadShootRightMouseButton(_weaponDescription));
    }

    private void InstantiateWeaponObject(Transform shootPosition)
    {
        WeaponFactory.CreateShoot(_weaponDescription, shootPosition);
    }

    private void SetAnimatorTrigger(int trigger)
    {
        _container.ShipAnimator.SetTrigger(trigger);
    }

    private IEnumerator ReloadShootLeftMouseButton(WeaponDescription weaponDescription)
    {
        _readyToFireLeft = false;
        yield return new WaitForSeconds(weaponDescription.GetWeaponCooldown());
        _readyToFireLeft = true;
    }
    
    private IEnumerator ReloadShootRightMouseButton(WeaponDescription weaponDescription)
    {
        _readyToFireRight = false;
        yield return new WaitForSeconds(weaponDescription.GetWeaponCooldown());
        _readyToFireRight = true;
    }
}