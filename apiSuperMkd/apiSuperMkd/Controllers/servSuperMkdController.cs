using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using apiSuperMkd.Models;
using apiSuperMkd.Clases;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace apiSuperMkd.Controllers
{
    // 61269
    [EnableCors(origins: "http://localhost:61269", headers: "*", methods:"*")]
    public class servSuperMkdController : ApiController
    {

        // POST api/<controller>
        public ModSuperMkd Post([FromBody] ModSuperMkd objIn) // insert
        {
            OpeSuperMkd objOpe = new OpeSuperMkd();
            objOpe.objModMdo = objIn;
            objOpe.hallarDatos();
            return objOpe.objModMdo;
        }
    }
}