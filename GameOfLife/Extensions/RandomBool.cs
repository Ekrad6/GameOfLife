namespace GameOfLife.Extensions;

internal class RandomBool : Random
{
    private uint _boolBits;
    public RandomBool() : base() { }
    public RandomBool(int seed) : base(seed) { }

    public bool NextBool()
    {
        _boolBits >>= 1;
        if (_boolBits <= 1) _boolBits = (uint)~this.Next();
        return (_boolBits & 1) == 0;
    }
}
