
namespace Versionizer
{
    public static class Extender
    {
        public static string Strip(this string o, params string[] chars)
        {
            foreach (var i in chars)
                o = o.Replace(i, string.Empty);

            return o;
        }
    }
}