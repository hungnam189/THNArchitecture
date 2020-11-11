using System.Text.Json;

namespace THN.Infrastructure.Common.ExtentionHelpers
{
    public class JsonHelper
    {
        public static string SerializeObject(object data)
        {
            if (data == null)
                return string.Empty;

            return JsonSerializer.Serialize(data);
        }

        public static object DeserializeObject(string data)
        {
            if (data == null)
                return string.Empty;

            return JsonSerializer.Deserialize<object>(@data);
        }

    }
}
