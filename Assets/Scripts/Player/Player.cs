using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAttacker))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private List<Weapon> _weaponList;

    private PlayerAttacker _attacker;
    private Weapon _currentWeapon;
    private bool _isCanMove;

    public float MoveSpeed => _moveSpeed;
    public Weapon CurrentWeapon => _currentWeapon;
    public bool IsCanMove => _isCanMove;

    private void Awake()
    {
        _attacker = GetComponent<PlayerAttacker>();
        _currentWeapon = _weaponList[0];
    }

    private void OnEnable()
    {
        _attacker.AttackStarted += OnAttackStarted;
        _attacker.AttackEnded += OnAttackEnded;
    }

    private void OnDisable()
    {
        _attacker.AttackStarted -= OnAttackStarted;
        _attacker.AttackEnded -= OnAttackEnded;
    }

    private void OnAttackStarted()
    {
        _isCanMove = false;
    }

    private void OnAttackEnded()
    {
        _isCanMove = true;
    }
}
