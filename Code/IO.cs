using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.IO.IsolatedStorage;

namespace IODemo
{
    class Program
    {
        const string FOLDER_PATH = @"C:\DemoTemp\IODemo\";

        static void Main(string[] args)
        {
            // Create demo folder
            if (!Directory.Exists(FOLDER_PATH))
                Directory.CreateDirectory(FOLDER_PATH);

            //EnumeratingDrives();
            //EnumeratingFilesAndFolders();
            //MonitoringFileSystem();
            //TextFiles();
            //BinaryFiles();
            //MemoryStreams();
            //Strings();
            //CompressedStreams();
            //IsolatedStorage();
        }

        static void EnumeratingDrives()
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
                Console.WriteLine("{0}, {1}", drive.Name, drive.DriveType);
        }

        static void EnumeratingFilesAndFolders()
        {
            foreach (DirectoryInfo dir in new DirectoryInfo(FOLDER_PATH).GetDirectories())
            {
                Console.WriteLine(dir.Name);

                foreach (FileInfo file in dir.GetFiles())
                    Console.WriteLine("\t{0}", file.Name);
            }
        }

        static void MonitoringFileSystem()
        {
            FileSystemWatcher fsw = new FileSystemWatcher(FOLDER_PATH);
            fsw.Created += new FileSystemEventHandler(fsw_Created);
            fsw.WaitForChanged(WatcherChangeTypes.Created);
        }

        static void fsw_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("{0} ({1})", e.FullPath, e.ChangeType);
            Console.ReadKey();
        }

        static void TextFiles()
        {
            string filePath = string.Concat(FOLDER_PATH, "Test.txt");

            // Write
            StreamWriter tw = File.CreateText(filePath); // TextWriter would work as well
            tw.WriteLine("Text");
            tw.Close();

            // Read
            StreamReader sr = new StreamReader(filePath);
            string line;

            while ((line = sr.ReadLine()) != null)
                Console.WriteLine(line);
        }

        static void BinaryFiles()
        {
            string filePath = string.Concat(FOLDER_PATH, "Test.bin");

            // Write
            FileStream fs = new FileStream(filePath, FileMode.Create); // Will create or overwrite
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write("Test");
            bw.Write(10);
            bw.Close();
            fs.Close();

            // Read
            fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            string s = br.ReadString();
            int i = br.ReadInt32();

            Console.WriteLine("string: {0}, int: {1}", s, i);

            br.Close();
            fs.Close();
        }

        static void MemoryStreams()
        {
            // Write
            MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter(ms);
            sw.WriteLine("MemoryData");

            sw.Flush(); // Write any buffered content            

            // Read
            ms.Seek(0, SeekOrigin.Begin); // Must rewind stream to the beginning
            StreamReader sr = new StreamReader(ms);
            Console.WriteLine(sr.ReadLine());

            sr.Close();
            sw.Close();
            ms.Close();
        }

        static void Strings()
        {
            // Write
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            sw.WriteLine("StringData");
            sw.Close();

            // Read
            StringReader sr = new StringReader(sb.ToString());
            Console.WriteLine(sr.ReadLine());
            sr.Close();
        }

        static void CompressedStreams()
        {
            string filePath = string.Concat(FOLDER_PATH, "Test.zip");

            // Write
            FileStream fs = new FileStream(filePath, FileMode.Create);
            GZipStream gs = new GZipStream(fs, CompressionMode.Compress);
            StreamWriter sw = new StreamWriter(gs);
            
            sw.WriteLine("CompressedData");
            sw.Close();
            gs.Close();
            fs.Close();

            // Read
            fs = new FileStream(filePath, FileMode.Open);
            gs = new GZipStream(fs, CompressionMode.Decompress);
            StreamReader sr = new StreamReader(gs);
            Console.WriteLine(sr.ReadLine());

            sr.Close();
            gs.Close();
            fs.Close();
        }

        static void IsolatedStorage()
        {
            // Write
            IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForAssembly();
            IsolatedStorageFileStream isfs =
                new IsolatedStorageFileStream("Test.txt", FileMode.Create, isf);
            StreamWriter sw = new StreamWriter(isfs);

            sw.WriteLine("IsoData");

            sw.Close();
            isfs.Close();
            isf.Close();

            // Read
            isf = IsolatedStorageFile.GetUserStoreForAssembly();
            isfs = new IsolatedStorageFileStream("Test.txt", FileMode.Open, isf);
            StreamReader sr = new StreamReader(isfs);
            Console.WriteLine(sr.ReadLine());

            sr.Close();
            isfs.Close();
            isf.Close();
        }
    }
}
