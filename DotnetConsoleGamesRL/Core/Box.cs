#region License
/*
MIT License

Copyright (c) 2022 bugbit

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

*/
#endregion

namespace DotnetConsoleGamesRL.Core;

public class Box : Space, IEquatable<Box>
{
    protected NumPyRandom RandomState;
    public NDArray? Low { get; }
    public NDArray? High { get; }

    /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
    public Box(int low, int high, Shape shape, Type? dType = null, int seed = -1) : this((float)low, (float)high, shape, dType, seed) { }

    public Box(float low, float high, Shape shape, Type? dType = null, int seed = -1) : base(shape, (dType = dType ?? np.float32))
    {
        if (Equals(shape, null)) throw new ArgumentNullException(nameof(shape));

        Low = (low + np.zeros(shape, dType)).astype(dType);
        High = (high + np.zeros(shape, dType)).astype(dType);
        RandomState = seed != -1 ? np.random.RandomState(seed) : np.random;
    }

    /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
    public Box(NDArray low, NDArray high, Type? dType = null, int seed = -1) : base(null, (dType = dType ?? np.float32))
    {
        if (Equals(low, null)) throw new ArgumentNullException(nameof(low));
        if (Equals(high, null)) throw new ArgumentNullException(nameof(high));
        Debug.Assert(low.shape.SequenceEqual(high.shape));
        Shape = low.shape;
        Low = low.astype(dType);
        High = high.astype(dType);
        RandomState = seed != -1 ? np.random.RandomState(seed) : np.random;
    }

    public override NDArray Sample()
    {
        return RandomState.uniform(Low, High, DType);
    }

    public override bool Contains(object ndArray)
    {
        if (ndArray is NDArray x)
            return x.shape == Shape && x >= Low && x <= High;
        throw new NotSupportedException(ndArray?.ToString() ?? nameof(ndArray));
    }

    public override void Seed(int seed)
    {
        RandomState = np.random.RandomState(seed);
    }

    #region Object Overrides

    /// <summary>Returns a string that represents the current object.</summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        return "Box" + Shape;
    }

    /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>
    /// <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.</returns>
    public bool Equals(Box? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Equals(Low, other.Low) && Equals(High, other.High);
    }

    /// <summary>Determines whether the specified object is equal to the current object.</summary>
    /// <param name="obj">The object to compare with the current object. </param>
    /// <returns>
    /// <see langword="true" /> if the specified object  is equal to the current object; otherwise, <see langword="false" />.</returns>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Box)obj);
    }

    /// <summary>Serves as the default hash function. </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode()
    {
        unchecked
        {
            return ((Low != null ? Low.GetHashCode() : 0) * 397) ^ (High != null ? High.GetHashCode() : 0);
        }
    }

    /// <summary>Returns a value that indicates whether the values of two <see cref="T:Gym.Spaces.Box" /> objects are equal.</summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if the <paramref name="left" /> and <paramref name="right" /> parameters have the same value; otherwise, false.</returns>
    public static bool operator ==(Box left, Box right)
    {
        return Equals(left, right);
    }

    /// <summary>Returns a value that indicates whether two <see cref="T:Gym.Spaces.Box" /> objects have different values.</summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if <paramref name="left" /> and <paramref name="right" /> are not equal; otherwise, false.</returns>
    public static bool operator !=(Box left, Box right)
    {
        return !Equals(left, right);
    }

        #endregion
}