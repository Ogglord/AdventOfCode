namespace AdventOf.Code.Common;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

public struct Coord : IEnumerable<int>, IEquatable<Coord>
{
    private readonly int x;
    private readonly int y;
    private readonly int z;
    public int X { get => x; }
    public int Y { get => y; }
    public int Z { get => z; }

    public int this[int index]
    {
        get { return index == 0 ? x : index == 1 ? y : z; }
    }

    public Coord(int x, int y)
    {
        this.x = x;
        this.y = y;
        z = 0;
    }
    public Coord(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public static implicit operator (int, int)(Coord c) => (c.x, c.y);
    public static implicit operator Coord((int X, int Y) c) => new Coord(c.X, c.Y);
    public static implicit operator (int, int, int)(Coord c) => (c.x, c.y, c.z);
    public static implicit operator Coord((int X, int Y, int Z) c) => new Coord(c.X, c.Y, c.Z);

    public void Deconstruct(out int x, out int y)
    {
        x = this.x;
        y = this.y;
    }

    public void Deconstruct(out int x, out int y, out int z)
    {
        x = this.x;
        y = this.y;
        z = this.z;
    }

    public static Coord operator +(Coord a, Coord b)
    {
        return new Coord(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    public override bool Equals(object other) =>
        other is Coord c
            && c.x.Equals(x)
            && c.y.Equals(y)
            && c.z.Equals(z);

    // Implement IEquatable<T> https://stackoverflow.com/a/8952026/7532
    public bool Equals([AllowNull] Coord other) => x == other.x && y == other.y && z == other.z;


    public override int GetHashCode()
    //            => HashHelpers.Combine(HashHelpers.Combine(HashHelpers.Combine(HashHelpers.RandomSeed, x), y), z);
    {
        // based on Jon Skeet - hashcode of an int is just its value
        unchecked // Overflow is fine, just wrap
        {
            int hash = 17;
            hash = hash * 23 + x;
            hash = hash * 23 + y;
            hash = hash * 23 + z;
            return hash;
        }
    }
    // => x.GetHashCode() ^ y.GetHashCode() ^ z.GetHashCode();

    public override string ToString() => $"({x},{y},{z})";

    public IEnumerator<int> GetEnumerator()
    {
        yield return x;
        yield return y;
        yield return z;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
