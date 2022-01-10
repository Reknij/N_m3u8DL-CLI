using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_m3u8DL_CLI_core
{
    public static class PublicHelper
    {
        public static class Paths
        {
            static string appFilePath = Process.GetCurrentProcess().MainModule?.FileName ?? throw new NullReferenceException("app file path get null");
            public static string AppFilePath => appFilePath;

            static string appDirectoryPath = Path.GetDirectoryName(appFilePath) ?? throw new NullReferenceException("app directory path get null");
            public static string AppDirectoryPath => appDirectoryPath;
        }
        public static class Variable
        {
            
        }
    }
}
