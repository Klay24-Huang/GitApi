using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitApi.Models;
using GitApi.Models.Interface;
using GitApi.Models.Repository;
using GitApi.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GitApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemoteRepositoryController : ControllerBase
    {
        private IRepository<RemoteRepository> remoteRepositoryRepository;

        public RemoteRepositoryController(GitWebApiContext context)
        {
            this.remoteRepositoryRepository = new GenericRepository<RemoteRepository>(context);

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RemoteRepository>>> GetAllRemoteRepository()
        {
            return await remoteRepositoryRepository.GetAll();
        }

        [HttpPost]
        public ActionResult<IEnumerable<RemoteRepository>> PostRemoteRepository(RemoteRepository remoteRepository)
        {
            //先取得資料庫內已有的倉儲資料
            IEnumerable<RemoteRepository> allRemoteRepositories = GetAllRemoteRepository().Result.Value;
            RemoteRepositoryService remoteRepositoryService = new RemoteRepositoryService();
            //檢查是否重複新增
            var exist = remoteRepositoryService.CheckRomoteRepository(remoteRepository.RemoteRepositoryUrl,allRemoteRepositories);
            if (exist)
            {
                string error = "此倉儲已經存在";
                return StatusCode(StatusCodes.Status405MethodNotAllowed, error);
            }
            else
            {
                //在本地端clone專案
                GitCommandService gitCommandService = new GitCommandService();
                var cloneResult = gitCommandService.ExcuteCommand(new GitCommandInfo
                {
                    Command = "clone",
                    GitUrl = remoteRepository.RemoteRepositoryUrl,
                    FilePath = ProjectPath.Path
                });
                //在資料庫新增此倉儲資料
                if (cloneResult.IsSuccessful)
                {
                    remoteRepository.RemoteRepositoryId = Guid.NewGuid();
                    remoteRepository.ServerPath = cloneResult.Result + "/" + remoteRepositoryService.GetFolderName(remoteRepository.RemoteRepositoryUrl);
                    remoteRepositoryRepository.Create(remoteRepository);
                    return CreatedAtAction(nameof(GetAllRemoteRepository), remoteRepository);
                }
                else
                {
                    //當clone失敗
                    return StatusCode(StatusCodes.Status405MethodNotAllowed, cloneResult.ErrorMessage);
                }
                //return CreatedAtAction(nameof(GetRemoteRepository), GetRemoteRepository().Result.Value);
            }
        }
    }
   
}