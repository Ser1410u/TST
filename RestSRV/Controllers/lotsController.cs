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
    public class LotsController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _conf;
        public LotsController(ILogger<HomeController> logger, IConfiguration conf)
        {
            _logger = logger;
            _conf = conf;
        }
        [HttpGet]
        public Result<Lot> Get(int pharmID, int storeId, int goodId)
        {
            List<SqlParameter> parms = new List<SqlParameter>();
            if (pharmID >= 0)   parms.Add(new SqlParameter("pharmID", pharmID));
            if (storeId >= 0)   parms.Add(new SqlParameter("storeId", pharmID));
            if (goodId >= 0)    parms.Add(new SqlParameter("goodId" , pharmID));

            return DataEngine.S<Lot>(_logger, _conf["ConnectionString"]??"", "S_Lots", parms.ToArray());
        }
        [HttpDelete]
        public Result<Lot> Delete()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var ppp = JsonSerializer.Deserialize<tstDataBase>(reader.ReadToEndAsync().Result);
                return DataEngine.D<Lot>(_logger, _conf["ConnectionString"] ?? "", "D_Lots", new SqlParameter[] { new SqlParameter("id", ppp.id)});
            }

        }
        [HttpPut]
        public Result<Lot> Put()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var ppp = JsonSerializer.Deserialize<Lot>(reader.ReadToEndAsync().Result);

                return DataEngine.IU<Lot>(_logger, _conf["ConnectionString"] ?? "", "IU_Lots", new SqlParameter[] { 
                                                                                                      new SqlParameter("id", ppp.id is null? DBNull.Value:ppp.id)
                                                                                                      , new SqlParameter("storeId", ppp.storeId)
                                                                                                    , new SqlParameter("pharmID", ppp.pharmID)
                                                                                                    , new SqlParameter("goodId", ppp.goodId)
                                                                                                    , new SqlParameter("q", ppp.q) 
                                                                                                                      });
            }
        }
    }
}