using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    void Awake()
    {
        PlayerLocator.RegisterPlayer(transform);
    }
}