using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LinqFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string path=@"c:\windows";
            ShowLargeFilesWithoutLinq(path);
            ShowLargeFilesWithLinq(path);
        }

        private static void ShowLargeFilesWithLinq(string path)
        {
            var query = new DirectoryInfo(path).GetFiles()
                .OrderByDescending(f => f.Length).Take(5);
            foreach (var fileInfo in query.Take(5))
            {
                Console.WriteLine($"{fileInfo.Name,-20} _ {fileInfo.Length,10:N}");

            }

        }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            var directory=new DirectoryInfo(path);
            var files = directory.GetFiles();
            Array.Sort(files,new FIleInfoComparer());
            foreach (var file in files.Take(5))
            {
                Console.WriteLine($"{file.Name,-20} _ {file.Length,10:N}");
            }
        }
    }

    public class FIleInfoComparer:IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}
