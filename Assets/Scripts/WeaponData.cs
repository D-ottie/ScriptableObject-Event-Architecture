using System;
using UnityEngine;

[CreateAssetMenu (fileName = "WeaponData", menuName = "CustomScriptableObject/WeaponData")]
public class WeaponData : ScriptableObject
{

    [SerializeField] private string name;
    [SerializeField] private float damage;
    public Sprite weaponSprite;

    public float GetDamage()
    {
        return damage;
    }

    public string GetName()
    {
        return name;
    }

}
