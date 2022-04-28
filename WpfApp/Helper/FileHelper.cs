using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfApp.Helper
{
    public static class FileHelper
    {
        /// <summary>
        /// 取文件后缀名
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns>.格式</returns>
        public static string GetPostfixStr(string filename)
        {
            int start = filename.LastIndexOf(".");
            int length = filename.Length;
            string postfix = filename.Substring(start, length - start);
            return postfix;
        }

        /// <summary>
        /// 取文件名称
        /// </summary>
        /// <param name="fullFileName"></param>
        /// <returns></returns>
        public static string GetFileName(string fullFileName)
        {
            int start = fullFileName.LastIndexOf("\\");
            int length = fullFileName.Length;
            int end = fullFileName.LastIndexOf(".");
            string fileName = fullFileName.Substring(start + 1, end - start - 1);
            return fileName;
        }

        /// <summary>
        /// 写文件到文件开始位置
        /// </summary>
        /// <param name="FullPath">文件完整路径</param>
        public static bool WriteFileToFileStartPos(string content,string FullPath)
        {
            bool result = true;

            string pattern = @"^(?<dir>[\w\W]*)[\\](?<fileName>[^\\]*)$";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(FullPath);
            string dir = match.Groups["dir"].ToString();
            string fileName = match.Groups["fileName"].ToString();

            if (!System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }

            string temp = File.ReadAllText(FullPath);
            byte[] tempBytes = System.Text.Encoding.UTF8.GetBytes(temp);

            FileStream fs = null;
            try
            {
                fs = new FileStream(FullPath, FileMode.Open, FileAccess.Write);
                fs.Seek(0,SeekOrigin.Begin);
                //字节数组,字节偏移量,最多写入的字节数
                byte[] contentBytes = System.Text.Encoding.UTF8.GetBytes(content);
                fs.Write(contentBytes, 0, contentBytes.Length);
                fs.Write(tempBytes, 0, tempBytes.Length);
                fs.Flush();
            }
            catch(Exception e)
            {
                result = false;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="Path">文件路径</param>
        /// <returns></returns>
        public static string ReadFile(string Path)
        {
            string s = "";
            if (!System.IO.File.Exists(Path))
                s = null;
            else
            {
                StreamReader f2 = new StreamReader(Path, System.Text.Encoding.GetEncoding("gb2312"));
                s = f2.ReadToEnd();
                f2.Close();
                f2.Dispose();
            }

            return s;
        }

        /// <summary>
        /// 拷贝文件
        /// </summary>
        /// <param name="OrignFile">原始文件</param>
        /// <param name="NewFile">新文件路径</param>
        public static void FileCopy(string orignFile, string NewFile)
        {
            File.Copy(orignFile, NewFile, true);
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="Path">路径</param>
        public static void FileDel(string Path)
        {
            File.Delete(Path);
        }

        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="OrignFile">原始路径</param>
        /// <param name="NewFile">新路径</param>
        public static void FileMove(string orignFile, string NewFile)
        {
            File.Move(orignFile, NewFile);
        }

        /// <summary>
        /// 递归删除文件夹
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static void DeleteFolder(string dir)
        {
            if (Directory.Exists(dir)) //如果存在这个文件夹删除之 
            {
                foreach (string d in Directory.GetFileSystemEntries(dir))
                {
                    if (File.Exists(d))
                        File.Delete(d); //直接删除其中的文件 
                    else
                        DeleteFolder(d); //递归删除子文件夹 
                }
                Directory.Delete(dir); //删除已空文件夹 
            }
        }

        /// <summary>
        /// 递归复制文件夹
        /// </summary>
        /// <param name="srcPath">原始路径</param>
        /// <param name="aimPath">目标文件夹</param>
        public static void CopyDir(string srcPath, string aimPath)
        {
            try
            {
                // 检查目标目录是否以目录分割字符结束如果不是则添加之
                if (aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar)
                    aimPath += Path.DirectorySeparatorChar;
                // 判断目标目录是否存在如果不存在则新建之
                if (!Directory.Exists(aimPath))
                    Directory.CreateDirectory(aimPath);

                // 得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组
                string[] fileList = Directory.GetFileSystemEntries(srcPath);

                //只复制目录下面的文件
                //string[] fileList = Directory.GetFiles(srcPath);

                //遍历所有的文件和目录
                foreach (string file in fileList)
                {
                    //先当作目录处理如果存在这个目录就递归Copy该目录下面的文件
                    //这个方法可以区分出是文件还是路径
                    if (Directory.Exists(file))
                    {
                        //Path.GetFileName，在情况是路径或文件时，都能获取到最后一截
                        CopyDir(file, aimPath + Path.GetFileName(file));
                    }
                    //否则直接Copy文件
                    else
                    {
                        File.Copy(file, aimPath + Path.GetFileName(file), true);
                    }
                }
            }
            catch (Exception e)
            {
            }
        }

        /// <summary>
        /// 打开指定的文件。
        /// </summary>
        /// <param name="fileName">表示文件路径，包含文件名称。</param>
        public static void OpenFile(string fileName)
        {
            if (System.IO.File.Exists(fileName))
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.FileName = fileName;
                process.StartInfo.Verb = "Open";
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                process.Start();
            }
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static byte[] ReadFileBytes(string Path)
        {
            FileStream fs = null;
            byte[] buffer = null;
            try
            {
                FileInfo fi = new FileInfo(Path);
                long len = fi.Length;
                buffer = new byte[len];
                fs = new FileStream(Path, FileMode.Open);
                fs.Read(buffer, 0, (int)len);
            }
            catch
            {
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
            return buffer;
        }

        /// <summary>
        /// 检查路径和文件是否存在，不存在则创建一个空的
        /// </summary>
        /// <param name="fileFullPath"></param>
        public static void CheckFile(string fileFullPath)
        {
            //关于正则，较全的文档
            //https://www.cnblogs.com/caokai520/p/4511848.html 
            string pattern = @"^(?<dir>[\w\W]*)[\\](?<fileName>[^\\]*)$";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(fileFullPath);
            string dir = match.Groups["dir"].ToString();
            string fileName = match.Groups["fileName"].ToString();
            if (!Directory.Exists(dir))
            {
                DirectoryInfo info = Directory.CreateDirectory(dir);
            }
            if (!File.Exists(fileFullPath))
            {
                FileStream fileStream = File.Create(fileFullPath);
                fileStream.Close();
            }
        }


    }
}
