using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveS : MonoBehaviour
{
    [SerializeField] float healForce = 3;

    [SerializeField] Image playerHealthBar;
    [SerializeField] Image enemyHealthBar; 

    Transform fighter;
    Transform enemy;

    Player currentFighter;
    Enemy currentEnemy;

    public void ChooseFighter(Transform _fighter)
    {
        if (currentFighter != null) currentFighter.OnChoose();

        currentFighter = _fighter.GetComponent<Player>();
        fighter = _fighter;

        currentFighter.OnChoose();

        playerHealthBar.fillAmount = currentFighter.currentHealhtPoints/currentFighter.maxHealthPoints;
    }
    public void ChooseEnemy(Transform _enemy)
    {
        if(currentEnemy != null) currentEnemy.OnChoose();

        currentEnemy = _enemy.GetComponent<Enemy>();
        enemy = _enemy;

        currentEnemy.OnChoose();

        enemyHealthBar.fillAmount = currentEnemy.currentHealthPoints/currentEnemy.maxHealthPoints;
    }
    public void Attack()
    {
        if (enemy != null && fighter != null)
        {
            float fighterDamage = Random.Range(currentFighter.maxDamage / 2, currentFighter.maxDamage);

            currentEnemy.GetDamage(fighterDamage);

            enemyHealthBar.fillAmount = currentEnemy.currentHealthPoints / currentEnemy.maxHealthPoints;
        }
    }
    IEnumerator Defence()
    {
        float enemyDamage = Random.Range(currentEnemy.maxDamage / 2, currentEnemy.maxDamage);

        currentFighter.GetDamage(enemyDamage);

        playerHealthBar.fillAmount = currentFighter.currentHealhtPoints / currentFighter.maxHealthPoints;

        yield return new WaitForSeconds(2);
    }
    public void Healing()
    {
        if(fighter != null)
        {
            currentFighter.GetHeal(healForce);
            playerHealthBar.fillAmount = currentFighter.currentHealhtPoints / currentFighter.maxHealthPoints;
        }
    }
}