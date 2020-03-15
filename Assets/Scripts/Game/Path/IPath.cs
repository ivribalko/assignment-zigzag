using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZag.Game.Path
{
    public interface IPath
    {
        /// <summary>
        /// The list will be refilled.
        /// </summary>
        event Action<IReadOnlyList<ITile>> OnBlockSpawned;

        ITile Start();

        /// <summary>
        /// Move for  a relative amount.
        /// </summary>
        void Progress(Vector3 movement);

        void Clear();
    }
}