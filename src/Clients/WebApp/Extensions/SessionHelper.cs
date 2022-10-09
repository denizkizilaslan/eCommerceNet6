using Newtonsoft.Json;

namespace WebApp.Extensions
{
    public static class SessionHelper
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            string objectStr = JsonConvert.SerializeObject(value);
            session.SetString(key, objectStr);
        }
        public static T GetObject<T>(this ISession session, string key) where T : class
        {
            string objectStr = session.GetString(key);
            return objectStr == null ? default(T) : JsonConvert.DeserializeObject<T>(objectStr);
        }
    }
}
