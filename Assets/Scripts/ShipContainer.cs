using UnityEngine;
using Weapon;

public class ShipContainer : MonoBehaviour
{
    public Animator ShipAnimator;

    public string RightShootTrigger;
    public string LeftShootTrigger;

    [Space]
    public WeaponDescriptionCollection Weapon;
    public WeaponType CurrentWeapon;
    [Space]
    public Transform LeftShootPosition;
    public Transform RightShootPosition;
    
    [Space]
    public Transform[] RightMouseButtonShootPositions;
    
    [Space]
    public float ShipSpeed;

    [Space] public int Hitpoints;
    [Space] public GameObject DestroyFX;
}