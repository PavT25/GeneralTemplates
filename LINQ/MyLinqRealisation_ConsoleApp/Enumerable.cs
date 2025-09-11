namespace MyLinqRealisation_ConsoleApp
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

    }
}
