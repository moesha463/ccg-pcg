using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealthPoints;
    public float currentHealhtPoints;
    public float maxDamage;

    MoveS moveS;
    private void Start()
    {
        currentHealhtPoints = maxHealthPoints;
        moveS = FindObjectOfType<MoveS>();
    }
    private void OnMouseDown()
    {
        moveS.ChooseFighter(transform);
    }
    public void GetDamage(float _damage)
    {
        currentHealhtPoints -= _damage;

        if (currentHealhtPoints <= 0) Death();
    }
    public void GetHeal(float _healForce)
    {
        currentHealhtPoints += _healForce;
        currentHealhtPoints = Mathf.Clamp(currentHealhtPoints, 0, maxHealthPoints);
    }
    void Death()
    {
        Destroy(gameObject);
    }
}
