using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace KillerCodes
{
    public class XConsole
    {
        public static StreamWriter logstreamWriter;
        public static FileStream textLog;
        private static ConsoleColor Highlighter;
        private static TextReader reader = System.Console.In;
        private static TextWriter writer = System.Console.Out;
        public static int bufferHeight { get; private set; }

        //private static char Formatter;
        public static int bufferWidth { get; private set; }
        public static string LogFileName { get; set; }
        public static string Title { get; private set; }
        public static int windowHeight { get; private set; }
        public static int windowWidth { get; private set; }

        public static void DefaultColor()
        { System.Console.ResetColor(); }

        public static void Error(string Errormsg)
        {
            var defaultColor2 = System.Console.ForegroundColor;
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine(Errormsg);
            System.Console.ForegroundColor = defaultColor2;
        }

        public static void Fwrite(string Msg)
        {
            var tt = Msg.Split('<', '>', '{', '}', '[', ']');
            for (int i = 0; i < tt.Length; i++)
            {
                if (i % 2 == 0)
                {
                    var defaultColor1 = System.Console.ForegroundColor;
                    System.Console.ForegroundColor = Highlighter;
                    System.Console.Write(tt[i]);
                    System.Console.ForegroundColor = defaultColor1;
                }
                else
                {
                    System.Console.Write(tt[i]);
                }
            }
            System.Console.Write('\n');
        }

        public static void Initailize(string Title, Action intro, ConsoleColor highlighter)
        {
            SetTitle(Title);
            Interface(intro);
            Highlighter = highlighter;
            XConsole.SetBuffer(200, 300);
            XConsole.DefaultColor();
        }

        public static void Initailize(string Title, ConsoleColor highlighter)
        {
            SetTitle(Title);
            Highlighter = highlighter;
            XConsole.SetBuffer(200, 300);
            XConsole.SetWindow(122, 54);
            XConsole.DefaultColor();
            System.Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Interface(Action interfaceMethod)
        { interfaceMethod.Invoke(); }

        public static void OK(string Okmsg)
        {
            var defaultColor2 = System.Console.ForegroundColor;
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine(Okmsg);
            System.Console.ForegroundColor = defaultColor2;
        }

        public static string ReadLine()
        {
            return reader.ReadLine();
        }

        public static string ReadLine(string message)
        {
            writer.WriteLine(message);
            return ReadLine();
        }

        public static void SetBuffer(int width, int height)
        {
            bufferWidth = width;
            bufferHeight = height;
            System.Console.SetBufferSize(bufferWidth, bufferHeight);
        }

        public static void SetHighlightColor(ConsoleColor Color)
        { Highlighter = Color; }

        public static void SetReader(TextReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            XConsole.reader = reader;
        }

        public static void SetTitle(string Text)
        { System.Console.Title = Text; }
        public static void SetWindow(int width, int height)
        {
            windowWidth = width;
            windowHeight = height;
            System.Console.SetWindowSize(windowWidth, windowHeight);
        }
        public static void SetWriter(TextWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            XConsole.writer = writer;
        }
        public static void startTxtLog()
        {
            textLog = new FileStream(System.Console.Title.Replace("#", "") + ".txt", FileMode.Create);
            logstreamWriter = new StreamWriter(textLog);
            System.Console.SetOut(logstreamWriter);
        }

        public static void Status(string statusText)
        {
            var defaultColor4 = System.Console.ForegroundColor;
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            writer.WriteLine(statusText);
            System.Console.ForegroundColor = defaultColor4;
        }

        public static void stopTxtLog()
        {
            logstreamWriter.Close();
        }

        public static void WriteLine()
        {
            writer.WriteLine();
        }

        public static void WriteLine(string text)
        {
            writer.WriteLine(text);
        }

        public static void WriteLine(string format, params object[] args)
        {
            writer.WriteLine(format, args);
        }

        public static void Xwrite(string Msg)
        {
            var fMsg = Msg.Replace("</", "<").Replace("/>", ">").Replace(">", "> ").Replace("}", "} ").Replace("]", "] ").Replace("<", " <");
            var tt = fMsg.Split('<', '>', '{', '}', '[', ']');
            for (int i = 0; i < tt.Length; i++)
            {
                if (i % 2 == 0)
                {
                    System.Console.Write(tt[i]);
                }
                else
                {
                    var defaultColor1 = System.Console.ForegroundColor;
                    System.Console.ForegroundColor = Highlighter;
                    System.Console.Write(tt[i]);
                    System.Console.ForegroundColor = defaultColor1;
                }
            }
        }
    }
}
