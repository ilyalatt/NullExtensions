using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace NullExtensions {
    public static class NFlattenExtensions {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TSource> NFlatten<TSource>(
            this IEnumerable<TSource?> source
        ) where TSource : class =>
            (IEnumerable<TSource>) source.Where(x => x != null);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<TSource> NFlatten<TSource>(
            this IEnumerable<TSource?> source
        ) where TSource : struct =>
            source.Where(x => x != null).Select(x => x!.Value);
    }
}