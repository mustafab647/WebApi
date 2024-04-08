using ESCore.Model.Product;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.OpenApi.Extensions;
using System.Reflection;
using System.Linq.Expressions;


namespace WebApi.Helper
{
    public static class ReqProperties
    {
        public static List<string> GetProperties(object obj)
        {
            if (obj == null)
                return new List<string>();
            List<string> result = new List<string>();
            Newtonsoft.Json.Linq.JObject jsonToken = Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>((obj ?? "").ToString());
            IEnumerable<Newtonsoft.Json.Linq.JToken> b = (IEnumerable<Newtonsoft.Json.Linq.JToken>)jsonToken.Children();
            for (int i = 0; i < b.Count(); i++)
            {
                string propertyName = ((Newtonsoft.Json.Linq.JProperty)b.ToList()[i]).Name;
                result.Add(propertyName);
            }
            return result;
        }

        public static Expression<Func<T, bool>> GetExpression<T>(object obj) where T : class
        {
            List<string> properties = GetProperties(obj);

            var p = typeof(T).GetProperties();
            List<PropertyInfo> exp = new List<PropertyInfo>();
            foreach (string property in properties)
            {
                var pInf = p.FirstOrDefault(x => x.Name.ToLower().Equals(property.ToLower()));
                exp.Add(pInf);
            }
             Expression<Func<T, bool>> result = t => t.GetType().GetProperty(properties[0]).Name == properties[0];// typeof(T).GetProperties();
            //System.Linq.Expressions.Expression<Func<T, bool>>.

            string a = result.Print();
            //return result.Compile();
            return (result);
        }
        public static Expression<Func<T, object>> GetExpression<T>(object obj,bool two) where T: class
        {
            var parameter = Expression.Parameter(typeof(T), "x");

            string[] properties = GetProperties(obj).ToArray();
            var bindings = from propName in properties
                           let source = Expression.Property(parameter, propName)
                           let target = typeof(T).GetProperty(propName, true)
                           select Expression.Bind(target, source);
            var newExp = Expression.New(typeof(T));
            var body = Expression.MemberInit(newExp, bindings);
            return Expression.Lambda<Func<T, object>>(body, parameter);
            //return result;
        }

    }
}
