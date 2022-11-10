using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMover))]
public class PlayerMoveInput : PlayerInputBase
{
    private PlayerMover _mover;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        Vector2 direction = NewInput.Player.Move.ReadValue<Vector2>();

        if (direction != Vector2.zero)
            _mover.TryMove(direction);
        else
            _mover.Idle();
    }
}
