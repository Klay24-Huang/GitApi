using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitApi.Models;
using GitApi.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GitApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ABCController : ControllerBase
    {
        public ABCController(GitWebApiContext context)
        {

        }
        [HttpGet]
        public void test()
        {
            FolderService folderService = new FolderService();
            folderService.CheckFolderExist("avc\\123");
        }
    }
}