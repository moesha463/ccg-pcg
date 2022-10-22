using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealthPoints;
    public float currentHealthPoints;
    public float maxDamage;

    MoveS moveS;
    private void Start()
    {
        currentHealthPoints = maxHealthPoints;
        moveS = FindObjectOfType<MoveS>();
    }
    private void OnMouseDown()
    {
        moveS.ChooseEnemy(transform);
    }
    public void GetDamage(float _damage)
    {
        currentHealthPoints -= _damage;

        if (currentHealthPoints <= 0) Death();
    }
    void Death()
    {
        Destroy(gameObject);
    }
}
