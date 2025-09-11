namespace MyLinqRealisation_ConsoleApp.Functions
{
    public static class Enumerable
    {
        public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var element in source)
            {
                if (predicate.Invoke(element))
                {
                    yield return element;
                }
            }
        }

        public static IEnumerable<TResult> MySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (var element in source)
            {
                yield return selector.Invoke(element);
            }
        }
    }
}
