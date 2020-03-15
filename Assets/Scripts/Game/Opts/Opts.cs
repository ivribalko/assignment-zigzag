using System.Collections.Generic;
using UnityEngine;

namespace ZigZag.Game.Opts
{
    [CreateAssetMenu(fileName = "Opts", menuName = "ScriptableObject/Game/Opts", order = 0)]
    public class Opts : ScriptableObject, IOpts
    {
        public IReadOnlyList<Vector3> Directions => this.directions;

        public Vector3 TileSize => this.tileSize;

        public float Difficulty => this.difficulty;

        public float BallSpeed => this.ballSpeed;

        public float BallToTile => this.ballToTile;

        [SerializeField] private Vector3[] directions = new [] { Vector3.forward, Vector3.right };

        [SerializeField] private Vector3 tileSize = Vector3.one;

        [SerializeField] private float difficulty = 1f;

        [SerializeField] private float ballSpeed = 2f;

        [SerializeField] private float ballToTile = 0.5f;

    }
}