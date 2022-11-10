using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Animator))]
public class PlayerAttacker : MonoBehaviour
{
    private const string AnimatorOneHandedAttack = "OneHandedAttack";

    private Player _player;
    private Animator _animator;
    private bool _isAttacking;

    private Dictionary<Type, string> _animatorAttacks = new Dictionary<Type, string>()
    {
        { typeof(OneHandedWeapon), AnimatorOneHandedAttack }
    };

    public UnityAction AttackStarted;
    public UnityAction AttackEnded;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
    }

    public void TryAttack()
    {
        if (_isAttacking == false)
        {
            Weapon weapon = _player.CurrentWeapon;

            foreach (var key in _animatorAttacks.Keys)
            {
                if (key == weapon.GetType())
                {
                    Attack(_animatorAttacks[key], weapon.AttackDuration);
                }
            }
        }
    }

    private void Attack(string animatorState, float attackDuration)
    {
        AttackStarted?.Invoke();
        _isAttacking = true;
        _animator.Play(animatorState);
        StartCoroutine(CountAttackTime(attackDuration));
    }

    private IEnumerator CountAttackTime(float attackDuration)
    {
        float time = 0;

        while (time < attackDuration)
        {
            yield return null;

            time += Time.deltaTime;
        }

        AttackEnded?.Invoke();
        _isAttacking = false;
    }
}
