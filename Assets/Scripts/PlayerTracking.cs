using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracking : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _offsetFromPlayer;

    private void Update()
    {
        transform.position = new Vector3(_player.position.x + _offsetFromPlayer.x, _offsetFromPlayer.y, _player.position.z + _offsetFromPlayer.z);
    }
}
