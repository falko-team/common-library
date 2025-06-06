using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Falko.Common.Asserts;
using Falko.Common.Operators;

namespace Falko.Common.Sequences;

public partial class FrozenSequence<T> : SequenceOperator<T>.IFirstOperator
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T First()
    {
        SequenceExceptions.ThrowIfEmpty(_itemsCount);

        return _items[0];
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public T First(Func<T, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = 0; itemIndex < itemsCount; itemIndex++)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item)) return item;
        }

        SequenceExceptions.ThrowNotMatchAny();
        return default; // This line is unreachable
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public T First(Func<T, int, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = 0; itemIndex < itemsCount; itemIndex++)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item, itemIndex)) return item;
        }

        SequenceExceptions.ThrowNotMatchAny();
        return default; // This line is unreachable
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public T First<TArgument>(TArgument argument, Func<T, TArgument, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = 0; itemIndex < itemsCount; itemIndex++)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item, argument)) return item;
        }

        SequenceExceptions.ThrowNotMatchAny();
        return default; // This line is unreachable
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public T First<TArgument>(TArgument argument, Func<T, int, TArgument, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = 0; itemIndex < itemsCount; itemIndex++)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item, itemIndex, argument)) return item;
        }

        SequenceExceptions.ThrowNotMatchAny();
        return default; // This line is unreachable
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T? FirstOrDefault()
    {
        return _itemsCount is 0
            ? default
            : _items[0];
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public T? FirstOrDefault(Func<T, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = 0; itemIndex < itemsCount; itemIndex++)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item)) return item;
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public T? FirstOrDefault(Func<T, int, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = 0; itemIndex < itemsCount; itemIndex++)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item, itemIndex)) return item;
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public T? FirstOrDefault<TArgument>(TArgument argument, Func<T, TArgument, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = 0; itemIndex < itemsCount; itemIndex++)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item, argument)) return item;
        }

        return default;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public T? FirstOrDefault<TArgument>(TArgument argument, Func<T, int, TArgument, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(_items);
        var itemsCount = _itemsCount;

        for (var itemIndex = 0; itemIndex < itemsCount; itemIndex++)
        {
            var item = Unsafe.Add(ref itemsReference, itemIndex);

            if (predicate(item, itemIndex, argument)) return item;
        }

        return default;
    }
}
