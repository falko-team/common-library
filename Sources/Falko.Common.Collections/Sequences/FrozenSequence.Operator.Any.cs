using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Falko.Common.Operators;

namespace Falko.Common.Sequences;

public partial class FrozenSequence<T> : SequenceOperator<T>.IAnyOperator
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Any()
    {
        return _itemsCount > 0;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool Any(Func<T, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = 0; itemIndex < itemsCount; itemIndex++)
        {
            if (predicate(Unsafe.Add(ref itemsReference, itemIndex))) return true;
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool Any(Func<T, int, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = 0; itemIndex < itemsCount; itemIndex++)
        {
            if (predicate(Unsafe.Add(ref itemsReference, itemIndex), itemIndex)) return true;
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool Any<TArgument>(TArgument argument, Func<T, TArgument, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = 0; itemIndex < itemsCount; itemIndex++)
        {
            if (predicate(Unsafe.Add(ref itemsReference, itemIndex), argument)) return true;
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool Any<TArgument>(TArgument argument, Func<T, int, TArgument, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = 0; itemIndex < itemsCount; itemIndex++)
        {
            if (predicate(Unsafe.Add(ref itemsReference, itemIndex), itemIndex, argument)) return true;
        }

        return false;
    }
}
