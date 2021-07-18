using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace YJCallBackHost {
    class Program {
        //COPYDATASTRUCT構造体 
        /*public struct COPYDATASTRUCT
        {
            public Int32 dwData;      //送信する32ビット値
            public Int32 cbData;　　　//lpDataのバイト数
            public string lpData;　　 //送信するデータへのポインタ(0も可能)
        }

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern Int32 FindWindow(String lpClassName, String lpWindowName);
 
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern Int32 SendMessage(Int32 hWnd, Int32 Msg, Int32 wParam, ref COPYDATASTRUCT lParam);
 
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern Int32 SendMessage(Int32 hWnd, Int32 Msg, Int32 wParam, Int32 lParam);
 
        public const Int32 WM_COPYDATA = 0x4A;
        public const Int32 WM_USER = 0x400;
        static public void FomSendMessage(string str) {
            Int32 result = 0;

            //相手のウィンドウハンドルを取得
            Int32 hWnd = FindWindow(null, "アカウントの登録(Yahoo)");
            if (hWnd == 0) {
                //ハンドルが取得できなかった
                Console.WriteLine("相手Windowのハンドルが取得できません");
                return;
            }

            //文字列メッセージを送信
            //送信データをByte配列に格納
            COPYDATASTRUCT cds;
            cds.dwData = 0;　　　　　　　　//使用しない
            cds.lpData = str;//テキストのポインターをセット
            cds.cbData = cds.lpData.Length + 1;　//長さをセット
            //文字列を送る
            result = SendMessage(hWnd, WM_COPYDATA, 0, ref cds);

            //数値メッセージを送信
            Int32 int1 = 3;
            Int32 int2 = 2;
            //数値を送る
            result = SendMessage(hWnd, WM_USER, int1, int2);
        }

        static void SendMessage2() {
        }*/

        static void Main(string[] args){
            if (args.Length > 0) {
                try {
                    HttpListener listener = new HttpListener();
                    listener.Prefixes.Add("http://localhost:9999/");
                    listener.Start();
                    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                    sw.Start();
                    while (true) {
                        Thread.Sleep(1000);
                        HttpListenerContext context = listener.GetContext();
                        HttpListenerResponse res = context.Response;
                        res.StatusCode = 200;
                        byte[] content = Encoding.UTF8.GetBytes(args[0]);
                        res.OutputStream.Write(content, 0, content.Length);
                        res.Close();
                        //ここにきたらアクセスがあった
                        return;
                        
                    }
                } catch (Exception ex) {
                    Console.WriteLine("Error: " + ex.Message);
                }
                Console.WriteLine("inko");
            } else {
                //FomSendMessage("test");
            }
            return;
        }
    }
}
