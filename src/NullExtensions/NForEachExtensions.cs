using System;
using System.Runtime.CompilerServices;

namespace NullExtensions {
    public static class NForEachExtensions {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NForEach<TSource>(
            this TSource? source,
            Action<TSource> action
        ) where TSource : class {
            if (source != null) {
                action(source);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NForEach<TSource>(
            this TSource? source,
            Action<TSource> action
        ) where TSource : struct {
            if (source.HasValue) {
                action(source.Value);
            }
        }
    }
}