using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player))]
public class PlayerMover : MonoBehaviour
{
    private const string AnimatorIsRun = "Is Run";

    private Player _player;
    private Animator _animator;
    private float _moveSpeed;

    public UnityAction OnMove;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _moveSpeed = _player.MoveSpeed;
        _animator = GetComponent<Animator>();
    }

    public void TryMove(Vector2 direction)
    {
        if (_player.IsCanMove)
        {
            float scaledMoveSpeed = _moveSpeed * Time.deltaTime;
            Vector3 move = new Vector3(direction.x, 0, direction.y);
            Vector3 nextPosition = transform.position + (move * scaledMoveSpeed);

            transform.LookAt(nextPosition);
            transform.position = nextPosition;

            _animator.SetBool(AnimatorIsRun, true);
        }
    }

    public void Idle()
    {
        _animator.SetBool(AnimatorIsRun, false);
    }
}
