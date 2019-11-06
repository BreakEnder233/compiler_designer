using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace word_compiler.Services.Input
{
    public static class FileManager
    {
        public static string ReadFile(string path)
        {
            string output = string.Empty;
            try
            {
                output = File.ReadAllText(path);
            }
            catch(Exception e)
            {

            }
            if (string.IsNullOrWhiteSpace(output))
            {
                throw new Exception("WDNMD");
            }
            return output;
        }

        public static void WriteFile(string path,string data)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }

            try
            {
                File.WriteAllText(path,data);
            }
            catch (Exception e)
            {

            }
        }
    }
}
