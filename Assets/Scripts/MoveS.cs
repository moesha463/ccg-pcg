using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveS : MonoBehaviour
{
    [Header("SuperForces")]
    [SerializeField] float healForce = 3;

    Transform fighter;
    Transform enemy;
    
    [SerializeField] FightersManager fightersManager;

    Player currentFighter;
    Enemy currentEnemy;

    public void ChooseFighter(Transform _fighter)
    {
        if (currentFighter != null) currentFighter.OnChoose();

        currentFighter = _fighter.GetComponent<Player>();
        fighter = _fighter;

        currentFighter.OnChoose();

        currentFighter.SetHPonHealthBar();
    }
    public void ChooseEnemy(Transform _enemy)
    {
        if(currentEnemy != null) currentEnemy.OnChoose();

        currentEnemy = _enemy.GetComponent<Enemy>();
        enemy = _enemy;

        currentEnemy.OnChoose();

        currentEnemy.SetHPonHealthBar();
    }
    public void Attack()
    {
        if (enemy != null && fighter != null && currentFighter.alreadyAtatcked == false)
        {
            float fighterDamage = Random.Range(currentFighter.maxDamage / 2, currentFighter.maxDamage);

            currentEnemy.GetDamage(fighterDamage);

            currentEnemy.SetHPonHealthBar();

            currentFighter.alreadyAtatcked = true;
        }
    }
    public void Defence()
    {
        float enemyDamage = Random.Range(currentEnemy.maxDamage / 2, currentEnemy.maxDamage);

        currentFighter.GetDamage(enemyDamage);

        currentFighter.SetHPonHealthBar();

        fightersManager.EndOfDefence();
    }
    public void Healing()
    {
        if(fighter != null)
        {
            currentFighter.GetHeal(healForce);
            currentFighter.SetHPonHealthBar();
        }
    }
}