using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace NullExtensions {
    public static class NChooseExtensions {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TResult> NChoose<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TResult?> selector
        ) where TResult : class =>
            source.Select(x => selector(x)!).Where(x => x != null);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TResult> NChoose<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TResult?> selector
        ) where TResult : struct =>
            source.Select(selector).Where(x => x.HasValue).Select(x => x!.Value);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TResult> NChoose<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, int, TResult?> selector
        ) where TResult : class =>
            source.Select((x, i) => selector(x, i)!).Where(x => x != null);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TResult> NChoose<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, int, TResult?> selector
        ) where TResult : struct =>
            source.Select(selector).Where(x => x.HasValue).Select(x => x!.Value);
    }
}