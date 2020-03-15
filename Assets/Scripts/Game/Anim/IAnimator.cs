using System;
using UnityEngine;

namespace ZigZag.Game.Anim
{
    public interface IAnimator
    {
        IDisposable Disappear(Component component);
    }
}