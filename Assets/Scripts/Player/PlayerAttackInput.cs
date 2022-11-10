using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAttacker))]
public class PlayerAttackInput : PlayerInputBase
{
    private PlayerAttacker _attacker;

    private void Start()
    {
        _attacker = GetComponent<PlayerAttacker>();

        NewInput.Player.Attack.performed += context => _attacker.TryAttack();
    }
}
