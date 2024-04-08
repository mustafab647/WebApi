using System.Linq.Expressions;
using System.Reflection;

namespace WebApi.Helper
{
    public static class HelperReflection
    {
        public static PropertyInfo? GetProperty(this Type type, string name, bool ignore)
        {
            string _name = name;
            var properties = type.GetProperties();
            PropertyInfo result = type.GetProperty(_name);
            result = properties.FirstOrDefault(x => x.Name.ToLower() == _name.ToLower());
            return result;
        }
    }
}
