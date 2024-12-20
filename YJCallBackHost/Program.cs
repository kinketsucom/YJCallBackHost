using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace YJCallBackHost {
    class Program {
        static void Main(string[] args) {
            while (true) {
                Thread.Sleep(1000);
                Console.WriteLine("Waiting for response ...");
                string exePath = Application.ExecutablePath;
                string exeDirectory = Application.StartupPath;
                string authFilePath = System.IO.Path.Combine(exeDirectory, "auth.txt");
                if (args.Length > 0) {
                    try {
                        Console.WriteLine(String.Format("args[0]:{0}", args[0]));
                        Console.WriteLine(authFilePath);
                        File.AppendAllText(authFilePath, args[0] + Environment.NewLine);
                        Console.WriteLine("token extracted.please close this window.");
                        return;
                    } catch (Exception ex) {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                } else {
                    //FomSendMessage("test");
                }
            }
        }
    }
}
