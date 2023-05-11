﻿using UnityEngine;
namespace Extension
{
    [System.Serializable]
    internal class DefaultColliderData
    {
        [field: SerializeField] public float Height { get; private set; } = 2f;
        [field: SerializeField] public float CenterY { get; private set; } = 1f;
        [field: SerializeField] public float Radius { get; private set; } = 0.2f;

    }
}
