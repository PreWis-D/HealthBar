using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent (typeof(Animator))]
public class Player : MonoBehaviour
{
    private Animator _animator;

    public event UnityAction HealthChanged;

    public float Health { get; private set; } = 100f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnValidate()
    {
        Health = Mathf.Clamp(Health, 0f, 100f);
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        HealthChanged?.Invoke();
        OnValidate();
        _animator.SetTrigger("TakeDamage");
    }

    public void Healing(float health)
    {
        Health += health;
        HealthChanged?.Invoke();
        OnValidate();
        _animator.SetTrigger("Healing");
    }
}