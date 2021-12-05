using System;
using System.Runtime.CompilerServices;

namespace NullExtensions {
    public static class NSelectManyExtensions2 {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult? NSelectMany<TSource, TResult>(
            this TSource? source,
            Func<TSource, TResult?> selector
        ) where TSource : class where TResult : struct =>
            source != null ? selector(source) : default(TResult?);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult? NSelectMany<TSource, TResult>(
            this TSource? source,
            Func<TSource, TResult?> selector
        ) where TSource : struct where TResult : class =>
            source.HasValue ? selector(source.Value) : default(TResult?);
    }
}