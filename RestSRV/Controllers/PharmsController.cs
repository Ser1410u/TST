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
    public class PharmsController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _conf;
        public PharmsController(ILogger<HomeController> logger, IConfiguration conf)
        {
            _logger = logger;
            _conf = conf;
        }
        [HttpGet]
        public Result<Pharm> Get()
        {
            try
            {
                return DataEngine.S<Pharm>(_logger, _conf["ConnectionString"] ?? "", "S_Pharms", Array.Empty<SqlParameter>());
            }
            catch (Exception err)
            {
                return new Result<Pharm>() { Success = false, Code = err.HResult, Description = err.Message };
            }
        }
        [HttpDelete]
        public Result<Pharm> Delete()
        {
            try
            {
                using (var reader = new StreamReader(Request.Body))
                {
                    var ppp = JsonSerializer.Deserialize<tstDataBase>(reader.ReadToEndAsync().Result);
                    return DataEngine.D<Pharm>(_logger, _conf["ConnectionString"] ?? "", "D_Pharms", new SqlParameter[] { new SqlParameter("id", ppp.id) });
                }
            }
            catch (Exception err)
            {
                return new Result<Pharm>() { Success = false, Code = err.HResult, Description = err.Message };
            }

        }
        [HttpPut]
        public Result<Pharm> Put()
        {
            try
            {
                using (var reader = new StreamReader(Request.Body))
                {
                    var ppp = JsonSerializer.Deserialize<Pharm>(reader.ReadToEndAsync().Result);

                    return DataEngine.IU<Pharm>(_logger, _conf["ConnectionString"] ?? "", "IU_Pharms", new SqlParameter[]
                                                                                                        { new SqlParameter("id", ppp.id is null? DBNull.Value:ppp.id)
                                                                                                    , new SqlParameter("name", ppp.name)
                                                                                                    , new SqlParameter("address", ppp.address)
                                                                                                    , new SqlParameter("phone", ppp.phone) });
                }
            }
            catch (Exception err)
            {
                return new Result<Pharm>() { Success = false, Code = err.HResult, Description = err.Message };
            }
        }
    }
}