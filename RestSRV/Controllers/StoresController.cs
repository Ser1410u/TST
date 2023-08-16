using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestSRV.Classes;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Xml.Linq;
using System.Text.Json;
using System.Data;

namespace RestSRV.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoresController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _conf;
        public StoresController(ILogger<HomeController> logger, IConfiguration conf)
        {
            _logger = logger;
            _conf = conf;
        }
        [HttpGet]
        public Result<Store> Get(int pharmID)
        {
            SqlParameter[] parms = pharmID >= 0 ? new SqlParameter[] { new SqlParameter("pharmID", pharmID) }: Array.Empty<SqlParameter>();
            return DataEngine.S<Store>(_logger, _conf["ConnectionString"]??"", "S_Stores", parms);
        }
        [HttpDelete]
        public Result<Store> Delete()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var ppp = JsonSerializer.Deserialize<tstDataBase>(reader.ReadToEndAsync().Result);
                return DataEngine.D<Store>(_logger, _conf["ConnectionString"] ?? "", "D_Stores", new SqlParameter[] { new SqlParameter("id", ppp.id)});
            }

        }
        [HttpPut]
        public Result<Store> Put()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var ppp = JsonSerializer.Deserialize<Store>(reader.ReadToEndAsync().Result);

                return DataEngine.IU<Store>(_logger, _conf["ConnectionString"] ?? "", "IU_Stores", new SqlParameter[] { 
                                                                                                      new SqlParameter("id", ppp.id is null? DBNull.Value:ppp.id)
                                                                                                    , new SqlParameter("pharmID", ppp.pharmID) 
                                                                                                    , new SqlParameter("name", ppp.name) 
                                                                                                                      });
            }

        }
    }
}