using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitApi.Models;
using GitApi.Models.Interface;
using GitApi.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GitApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private IRepository<RemoteRepository> remoteRepositoryRepository;

        public BranchController(GitWebApiContext context)
        {
            remoteRepositoryRepository = new GenericRepository<RemoteRepository>(context);

        }

        //RemoteRepositoryController remoteRepositoryController = new RemoteRepositoryController();

        private BranchRepository branchRepository;
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<branch>>> GetAllBranch(QueryBranch queryBranch)
        //{
        //    //var allRemoteRepository = 
        //    return await branchRepository.GetAll(queryBranch.BranchName);
        //}
    }

   
}