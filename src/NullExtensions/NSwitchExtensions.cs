using System;
using System.Runtime.CompilerServices;

namespace NullExtensions {
    public static class NSwitchExtensions {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NSwitch<TSource>(
            this TSource? source,
            Action<TSource> some,
            Action none
        ) where TSource : class {
            if (source != null) {
                some(source);
            }
            else {
                none();
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NSwitch<TSource>(
            this TSource? source,
            Action<TSource> some,
            Action none
        ) where TSource : struct {
            if (source.HasValue) {
                some(source.Value);
            }
            else {
                none();
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult NSwitch<TSource, TResult>(
            this TSource? source,
            Func<TSource, TResult> some,
            Func<TResult> none
        ) where TSource : class =>
            source != null ? some(source) : none();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult NSwitch<TSource, TResult>(
            this TSource? source,
            Func<TSource, TResult> some,
            Func<TResult> none
        ) where TSource : struct =>
            source.HasValue ? some(source.Value) : none();
    }
}