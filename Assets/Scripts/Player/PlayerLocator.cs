using UnityEngine;
using System;

public class PlayerLocator
{
    public static event Action<Transform> OnPlayerSpawned;

    private static Transform _playerInstance;
    public static Transform PlayerInstance => _playerInstance;

    public static void RegisterPlayer(Transform player)
    {
        _playerInstance = player;
        OnPlayerSpawned?.Invoke(_playerInstance);
    }
}
