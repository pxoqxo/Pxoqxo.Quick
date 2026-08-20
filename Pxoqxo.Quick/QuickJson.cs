using System.Text.Json;

namespace Pxoqxo.Quick
{
    public static class QuickJson
    {
        public static string? ToJson<T>(T model)
        {
            try
            {
                return JsonSerializer.Serialize<T>(model);
            }
            catch
            {
                return null;
            }
        }
        public static T? FromJson<T>(string json)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(json);
            }
            catch
            {
                return default;
            }
        }
    }
}
