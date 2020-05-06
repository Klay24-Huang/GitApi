using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GitApi.service
{
    /// <summary>
    /// check 路徑是否有資料夾存在，沒有就建立
    /// </summary>
    public class FolderService
    {
        public void CheckFolderExist(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                //Directory.CreateDirectory(@$".\\project\\{folderPath}");
            }
        }
        /// <summary>
        /// 取得當前目錄的上一層
        /// </summary>
        /// <returns></returns>
        public string GetParentPath()
        {
            string currentPath = Directory.GetCurrentDirectory();
            return Directory.GetParent(currentPath).FullName.Replace("\\","/");

        }
    }
}
