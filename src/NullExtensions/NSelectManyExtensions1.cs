using System;
using System.Runtime.CompilerServices;

namespace NullExtensions {
    public static class NSelectManyExtensions1 {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult? NSelectMany<TSource, TResult>(
            this TSource? source,
            Func<TSource, TResult?> selector
        ) where TSource : class where TResult : class =>
            source != null ? selector(source) : default(TResult?);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult? NSelectMany<TSource, TResult>(
            this TSource? source,
            Func<TSource, TResult?> selector
        ) where TSource : struct where TResult : struct =>
            source.HasValue ? selector(source.Value) : default(TResult?);
    }
}