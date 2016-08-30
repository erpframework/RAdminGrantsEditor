using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RadminGrantsEditor
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] Args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SplashForm sf = null;
            bool _batch = false;
            bool _batchres = true;
            bool _openedconfig = false;
            if (Args.Length > 0)
            {
                // redirect console output to parent process;
                // must be before any calls to Console.WriteLine()
                AttachConsole( ATTACH_PARENT_PROCESS );
                sf = new SplashForm();
                sf.Show();
            }
            MainForm mf = new MainForm();
            mf.splash = sf;
            Application.DoEvents();
            for (int i = 0; i < Args.Length;i++ )
            {
                if ((Args[i] == "--connect") || (Args[i] == "/C")|| (Args[i] == "-C"))
                {
                    Console.Write("Connecting to " + Args[i + 1] + "...");
                    mf.RemoteName = Args[++i];
                    Console.WriteLine("OK");
                    continue;
                }
                if ((Args[i] == "--open") || (Args[i] == "/O") || (Args[i] == "-O"))
                {
                    Console.Write("Opening .rage file " + Args[i + 1] + "...");
                    if (mf.OpenFile(Args[++i]) == 0)
                    {
                        mf.UpdateUsersList();
                        _openedconfig = true;
                        Console.WriteLine("OK");
                    }
                    else
                    {
                        Console.WriteLine("ERROR");
                    }
                    continue;
                }
                if ((Args[i] == "--write") || (Args[i] == "/W") || (Args[i] == "-W"))
                {
                    
                    
                        _batch = true;
                        Console.Write("Writing settings to " + Args[i + 1] + "...");
                        bool res = false;
                        if (_openedconfig)
                        {
                            //mf.RemoteName = Args[++i];
                            res = mf.WriteTo(Args[++i]);
                        }
                        else
                        {
                            mf.LastTextMessage = "Settings file not opened!";
                        }
                        Console.WriteLine(res ? "OK" : "Error - " + mf.LastTextMessage);
                    _batchres = _batchres && res;
                    continue;
                }
            }
            mf.splash = null;
            if (sf != null)
            {
                sf.Close();
                sf.Dispose();
            }
            if (!_batch)
            {
                Application.Run(mf);
            }
            else
            {
                Console.WriteLine("Exit.");
                Environment.ExitCode=(_batchres)?0:29;
                
            }
            
        }
    }
}
