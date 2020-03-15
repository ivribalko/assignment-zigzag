using System;
using UnityEngine;

namespace ZigZag.Game.Opts
{
    [Serializable]
    internal class DifficultyData
    {
        [SerializeField] internal Difficulty difficulty;
        [SerializeField] internal float tileFactor;
    }
}