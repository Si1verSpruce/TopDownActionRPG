using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackRangeLength;
    [SerializeField] private float _attackRangeWidth;
    [SerializeField] private float _attackDuration;
    [SerializeField] private float _fromAttackToHitDelay;

    public float AttackDuration => _attackDuration;
}
