using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float maxHealthPoints;
    public float currentHealthPoints;
    public float maxDamage;
    public float speed;

    [SerializeField] Image healthBar;
    [SerializeField] GameObject circleOfChoose;

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
    public void OnChoose()
    {
        circleOfChoose.SetActive(!circleOfChoose.activeSelf);
    }
    public void GetDamage(float _damage)
    {
        currentHealthPoints -= _damage;

        if (currentHealthPoints <= 0) Death();
    }
    public void SetHPonHealthBar()
    {
        healthBar.fillAmount = currentHealthPoints / maxHealthPoints;
    }
    void Death()
    {
        Destroy(gameObject);
    }
}
