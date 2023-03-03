using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine.UI;
public class EnemyUI: MonoBehaviour {

  public EnemyProperties[] enemyProperties;
  public GameObject[] enemies;
  private List<GameObject> enemyList;
  public ProgressBar m_enemyHealthTextBar;
  public TextMeshProUGUI m_enemyNameText;
  public TextMeshProUGUI m_healthText;
  public TextMeshProUGUI m_coinsReceivedText;
  public IntEvent onEnemyDestroyed;
  public IntEvent onLevelFinished;
  public IntEvent onAttack;
  private WeaponData currentWeapon;
  private int m_totalcoins = 0;
  private int m_enemyIndex = 0;


  private void Start() 
  {
    currentWeapon = new WeaponData();
    // enemyList = new List<GameObject>();
    // foreach(var enemy in enemyProperties)
    // {
    //     GameObject currentEnemy = Instantiate(enemy.enemyPrefab, enemySpawnPosition.position, enemySpawnPosition.rotation);
    //     //currentEnemy.SetParent("EnemyUI");
    //     currentEnemy.SetActive(false);
    //     enemyList.Add(currentEnemy);
    // }
    // enemyList[m_enemyIndex].SetActive(true);
    enemies[m_enemyIndex].SetActive(true);
    m_enemyHealthTextBar.BarValue = 100;
    UpdateCoinsReceived();
  }
  private void Update() 
  {   

    if(Input.GetMouseButtonDown(0))
    {
       if(m_enemyIndex > enemyProperties.Length-1)
       return;

       if (currentWeapon.GetName() == enemyProperties[m_enemyIndex].GetMurderWeapon())
       {
          enemyProperties[m_enemyIndex].Damage(currentWeapon.GetDamage());
          onAttack.Raise(0);
       }
    }

    if(m_enemyIndex > enemyProperties.Length-1)
        return;
    
    m_healthText.text = (enemyProperties[m_enemyIndex].GetMaxHealth() - enemyProperties[m_enemyIndex].GetHealth()).ToString();
    m_enemyNameText.text = enemyProperties[m_enemyIndex].name;

  }
  public void NextEnemy()
  {
      m_enemyIndex++;
      if(m_enemyIndex == enemyProperties.Length)
      {
        onLevelFinished.Raise(0);
      }
      else
      {
        UpdateEnemy();
      }
      
  }
  public void UpdateWeapon(WeaponData _weaponData)
  {
    currentWeapon = _weaponData;
    
  }

  public void UpdateHealthBar()
  {
    m_enemyHealthTextBar.BarValue = (enemyProperties[m_enemyIndex].GetHealth()/enemyProperties[m_enemyIndex].GetMaxHealth()) * 100;
    if (enemyProperties[m_enemyIndex].GetHealth() > 0) return;
    m_enemyHealthTextBar.BarValue = 100;
    onEnemyDestroyed.Raise(0);
    NextEnemy();
  }

  public void UpdateCoinsReceived()
  {
    m_coinsReceivedText.text = m_totalcoins.ToString() + "\nCOINS";
    m_totalcoins += enemyProperties[m_enemyIndex].GetCoins();
  }

  public void UpdateEnemy()
  {
      for(int i = 0 ; i < m_enemyIndex ; i++)
      {
        enemies[i].SetActive(false);
      }
      enemies[m_enemyIndex].SetActive(true);

  }

}
