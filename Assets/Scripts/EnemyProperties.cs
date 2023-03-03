using UnityEngine;
using System;
using UnityEngine.Events;

// creating asset menu shows scriptable object in editor menu. We will be able to create this object from there 
[CreateAssetMenu(fileName = "EnemyProperties", menuName = "CustomScriptableObject/EnemyProperties")]
public class EnemyProperties: ScriptableObject 
{
  [SerializeField] private float health;
  [SerializeField] private float maxHealth;
  [SerializeField] private string name;
  [SerializeField] private string murderWeapon;
  [SerializeField] private int coins;

  public GameObject enemyPrefab;
  
  void Start()
  {
      health = maxHealth;
  }
  public void Damage(float damage) 
  {
    if (damage < 0) return;
    health -= damage;
  }

  // get current health
  public float GetHealth() 
  {
    return health;
  }
  public float GetMaxHealth()
  {
      return maxHealth;
  }
  public string GetName() 
  {
    return name;
  }
  public string GetMurderWeapon()
  {
      return murderWeapon;
  }
  public int GetCoins()
  {
      return coins;
  }

}