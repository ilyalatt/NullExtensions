using System;
using System.Runtime.CompilerServices;

namespace NullExtensions {
    public static class NWhereExtensions {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource? NWhere<TSource>(
            this TSource? source,
            Func<TSource, bool> predicate
        ) where TSource : class =>
            source != null && predicate(source) ? source : default(TSource?);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource? NWhere<TSource>(
            this TSource? source,
            Func<TSource, bool> predicate
        ) where TSource : struct =>
            source.HasValue && predicate(source.Value) ? source : default(TSource?);
    }
}