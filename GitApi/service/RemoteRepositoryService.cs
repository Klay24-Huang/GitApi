using GitApi.Models;
using GitApi.Models.Interface;
using GitApi.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitApi.service
{
    public class RemoteRepositoryService
    {
        /// <summary>
        /// 確認新增倉儲是否已存在
        /// </summary>
        /// <param name="url">git 網址</param>
        public bool CheckRomoteRepository(string url, IEnumerable<RemoteRepository> remoteRepositories)
        {
            return remoteRepositories.Any(x => x.RemoteRepositoryUrl == url);
        }

        public string GetFolderName(string url)
        {
            return url.Replace(".git", "").Split(new String[] { "/" }, StringSplitOptions.RemoveEmptyEntries).Last();
        }
    }
}
