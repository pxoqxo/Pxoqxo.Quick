using Pxoqxo.Ext.Core;

namespace Pxoqxo.Quick
{
    public static class QuickFile
    {
        public static bool Write(string pathName, string data, bool append = false)
        {
            try
            {
                if (pathName.IsNullOrEmptyOrWhiteSpace())
                {
                    return false;
                }

                string directoryName = Path.GetDirectoryName(pathName) ?? string.Empty;
                if (directoryName != string.Empty)
                {
                    if (!Directory.Exists(directoryName))
                    {
                        Directory.CreateDirectory(directoryName);
                    }
                }

                if (append)
                {
                    File.AppendAllText(pathName, data);
                }
                else
                {
                    File.WriteAllText(pathName, data);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public static string? Read(string pathName)
        {
            try
            {
                if (pathName.IsNullOrEmptyOrWhiteSpace())
                {
                    return null;
                }

                if (!File.Exists(pathName))
                {
                    return null;
                }

                return File.ReadAllText(pathName);
            }
            catch
            {
                return null;
            }
        }
    }
}
