namespace ZigZag.Game.Loop
{
    internal abstract class State
    {
        abstract internal void Start();
        abstract internal bool Ended();
    }
}