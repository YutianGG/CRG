﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    private void Update()
    {
        transform.position = new Vector3(player.position.x, 0,-10);
    }
}
