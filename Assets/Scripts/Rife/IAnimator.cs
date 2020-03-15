using System;
using UnityEngine;

namespace ZigZag.Rife
{
    public interface IAnimator
    {
        IDisposable Disappear(Component component);
    }
}