using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace N_m3u8DL_CLI_core
{
    class LOGGER
    {
        public const int Default = 1;
        public const int Error = 2;
        public const int Warning = 3;

        public static string? LOGFILE;
        public static bool STOPLOG = false;
        public static string FindLog(string dir)
        {
            DirectoryInfo d = new DirectoryInfo(dir);
            foreach (FileInfo fi in d.GetFiles())
            {
                if (fi.Extension.ToUpper() == ".LOG")
                {
                    return fi.FullName;
                }
            }
            return "";
        }

        public static void InitLog()
        {
            if (LOGFILE == null)
                throw new NullReferenceException("LOGFILE is null");
            string LOGDIRECTORY = Path.GetDirectoryName(LOGFILE) ?? throw new NullReferenceException("Get directory path failed.");
            if (!Directory.Exists(LOGDIRECTORY))//若文件夹不存在则新建文件夹   
                Directory.CreateDirectory(LOGDIRECTORY); //新建文件夹
            //若文件存在则加序号
            int index = 1;
            var fileName = Path.GetFileNameWithoutExtension(LOGFILE);
            while (File.Exists(LOGFILE))
            {
                LOGFILE = Path.Combine(LOGDIRECTORY, $"{fileName}-{index++}.log");
            }
            string file = LOGFILE;
            string now = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string init = "LOG " + DateTime.Now.ToString("yyyy/MM/dd") + "\r\n"
                + "Save Path: " + Path.GetDirectoryName(LOGFILE) + "\r\n"
                + "Task Start: " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "\r\n"
                + "Task CommandLine: " + Environment.CommandLine;

            string argsFilePath = Path.Combine(PublicHelper.Paths.AppFilePath, "N_m3u8DL-CLI.args.txt");
            if (File.Exists(argsFilePath))
            {
                init += "\r\nAdditional Args: " + File.ReadAllText(argsFilePath);  //解析命令行
            }

            init += "\r\n\r\n";
            File.WriteAllText(file, init, Encoding.UTF8);
        }

        //读写锁机制，当资源被占用，其他线程等待
        static ReaderWriterLockSlim LogWriteLock = new ReaderWriterLockSlim();

        public static void PrintLine(string text, int printLevel = 1)
        {
            switch (printLevel)
            {
                case 0:
                    Console.Write("\r" + new string(' ', Console.WindowWidth - 1) + "\r");
                    Console.WriteLine(" ".PadRight(12) + " " + text);
                    break;
                case 1:
                    Console.Write("\r" + new string(' ', Console.WindowWidth - 1) + "\r");
                    Console.Write(DateTime.Now.ToString("HH:mm:ss.fff") + " ");
                    Console.WriteLine(text);
                    break;
                case 2:
                    Console.Write("\r" + new string(' ', Console.WindowWidth - 1) + "\r");
                    Console.Write(DateTime.Now.ToString("HH:mm:ss.fff") + " ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(text);
                    Console.ResetColor();
                    break;
                case 3:
                    Console.Write("\r" + new string(' ', Console.WindowWidth - 1) + "\r");
                    Console.Write(DateTime.Now.ToString("HH:mm:ss.fff") + " ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(text);
                    Console.ResetColor();
                    break;
            }
        }

        public static void WriteLine(string text)
        {
            if (STOPLOG)
                return;
            if (!File.Exists(LOGFILE))
                return;

            try
            {
                string file = LOGFILE;
                //进入写入
                LogWriteLock.EnterWriteLock();
                using (StreamWriter sw = File.AppendText(file))
                {
                    sw.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + " / (NORMAL) " + text, Encoding.UTF8);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                //释放占用
                LogWriteLock.ExitWriteLock();
            }
        }

        public static void WriteLineError(string text)
        {
            if (!File.Exists(LOGFILE))
                return;
            try
            {
                string file = LOGFILE;
                //进入写入
                LogWriteLock.EnterWriteLock();
                using (StreamWriter sw = File.AppendText(file))
                {
                    sw.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + " / (ERROR) " + text, Encoding.UTF8);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                //释放占用
                LogWriteLock.ExitWriteLock();
            }
        }

        public static void Show(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(DateTime.Now.ToString("o") + "  " + text);
            while (Console.ForegroundColor == ConsoleColor.Red)
                Console.ResetColor();
        }
    }
}
