using System.Reflection;

namespace Pxoqxo.Quick
{
    // The build action must be set to 'Embedded Resource.'
    public static class QuickResource
    {
        public static Stream? GetResourceStream(Assembly assembly, string resourceName)
        {
            try
            {
                return assembly.GetManifestResourceStream(resourceName);
            }
            catch
            {
                return null;
            }
        }
        public static string? GetResourceData(Assembly assembly, string resourceName)
        {
            try
            {
                using Stream? resourceStream = GetResourceStream(assembly, resourceName);
                if (resourceStream == null)
                {
                    return null;
                }

                using StreamReader resourceReader = new StreamReader(resourceStream);
                return resourceReader.ReadToEnd();
            }
            catch
            {
                return null;
            }
        }
        public static string ExtractResourceData(Assembly assembly, string resourceName)
        {
            try
            {
                using Stream? resourceStream = GetResourceStream(assembly, resourceName);
                if (resourceStream == null)
                {
                    return string.Empty;
                }

                string fileName = Path.GetTempFileName();
                using FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                resourceStream.CopyTo(fileStream);

                return fileName;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
