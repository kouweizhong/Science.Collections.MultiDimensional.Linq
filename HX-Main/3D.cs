﻿namespace System.Linq
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Provides extensions methods to 3-dimensional arrays.
    /// </summary>
    public static partial class ExtensionsTo3DArrays
    {
        /// <summary>
        /// Determines whether two arrays are equal by comparing their elements using an equality comparer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="second">The array to compare.</param>
        /// <param name="comparer">An equality comparer to use to compare elements.</param>
        /// <returns></returns>
        public static bool ArrayEqual<T>(this T[,,] source, T[,,] second, IEqualityComparer<T> comparer)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (second == null)
                throw new ArgumentNullException("second");

            if (comparer == null)
                throw new ArgumentNullException("comparer");

            int width = source.GetLength(0),
                height = source.GetLength(1),
                depth = source.GetLength(2);

            for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            for (int z = 0; z < depth; z++)
                if (!comparer.Equals(source[x, y, z], second[x, y, z]))
                    return false;

            return true;
        }
        /// <summary>
        /// Determines whether two arrays are equal by comparing their elements using the default equality comparer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="second">The array to compare.</param>
        /// <returns></returns>
        public static bool ArrayEqual<T>(this T[,,] source, T[,,] second) where T : IEquatable<T>
        {
            return source.ArrayEqual(second, EqualityComparer<T>.Default);
        }
    }
}

