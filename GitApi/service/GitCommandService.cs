using GitApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GitApi.service
{
    public class GitCommandService
    {
        public OperationResult ExcuteCommand(GitCommandInfo gitCommand)
        {
            OperationResult operationResult = new OperationResult();
            string result = string.Empty;
            //string username = "vitohuang";
            string url = gitCommand.GitUrl;
            FolderService folderService = new FolderService();
            string folderPath = folderService.GetParentPath()+gitCommand.FilePath;
            folderService.CheckFolderExist(folderPath);
            string totalCommand = $@"cd {folderPath} ; git {gitCommand.Command} {url};";
            #region test code
            //string encodepassword = "iisi@877051".Replace("@", "%40");
            //string totalCommand = $@"cd C:/Credential/IISI_NETTOOL ; git fetch http://{username}:{encodepassword}@finsrv01.iead.local/git/IISI_NETTOOL.git;";
            #endregion
            //獲取模組的完整路徑。  
            string path1 = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            //獲取和設定當前目錄(該程序從中啟動的目錄)的完全限定目錄  
            string path2 = System.Environment.CurrentDirectory;
            //獲取應用程式的當前工作目錄  
            string path3 = System.IO.Directory.GetCurrentDirectory();
            //獲取程式的基目錄  
            string path4 = System.AppDomain.CurrentDomain.BaseDirectory;
            //獲取和設定包括該應用程式的目錄的名稱  
            string path5 = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            try
            {
                using (Process proc = new Process())
                {
                    //proc.StartInfo.FileName = @"D:/git/bin/bash";
                    proc.StartInfo.FileName = GitPath.path;
                    proc.StartInfo.Arguments += "-c \" " + totalCommand + " \"";
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.StartInfo.RedirectStandardError = true;
                    proc.Start();

                    result += proc.StandardOutput.ReadToEnd();
                    result += proc.StandardError.ReadToEnd();

                    proc.WaitForExit();
                    proc.Dispose();
                }
            }
            catch (Exception ex)
            {
                //程式上的錯誤
                operationResult.ErrorMessage = "執行git指令時,發生錯誤。"+ex;
                operationResult.IsSuccessful = false;
            }
            if (result.Contains("fatal"))
            {
                //git指令執行的錯誤
                operationResult.ErrorMessage = "執行git指令時,發生錯誤。" + result;
                operationResult.IsSuccessful = false;
            }
            else
            {
                //指令成功
                operationResult.IsSuccessful = true;
                //回傳當前資料夾路徑
                operationResult.Result = folderPath;
            }
            return operationResult;
        }
    }

    public class GitCommandInfo
    {
        public string Command { get; set; }
        public string GitUrl { get; set; }
        public string FilePath { get; set; }
    }

    public static class GitPath
    {
        public static string path { get; set; }
    }
}
