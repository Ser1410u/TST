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
    public class GoodsController : ControllerBase
    {
        private readonly ILogger<GoodsController> _logger;
        private readonly IConfiguration _conf;

        public GoodsController(ILogger<GoodsController> logger, IConfiguration conf)
        {
            _logger = logger;
            _conf = conf;
        }
        [HttpGet("GoodsByPharm")]
        public Result<GoodByPharm> GET_GoodsByPharm(int id)
        {
            try
            {
                return DataEngine.S<GoodByPharm>(_logger, _conf["ConnectionString"] ?? "", "GET_GoodsByPharm", new SqlParameter[] { new SqlParameter("@pharmID", id) });
            }
            catch (Exception err)
            {
                return new Result<GoodByPharm>()
                {
                    Success = false,
                    Code = err.HResult,
                    Description = err.Message
                };
            }
        }

        [HttpGet]
        public Result<Good> Get()
        {
            try
            {
                return DataEngine.S<Good>(_logger, _conf["ConnectionString"] ?? "", "S_Goods", new SqlParameter[0]);
            }
            catch (Exception err)
            {
                return new Result<Good>() { Success = false, Code = err.HResult, Description = err.Message };
            }
        }
        [HttpDelete]
        public Result<Good> Delete()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                try
                {
                    var ppp = JsonSerializer.Deserialize<tstDataBase>(reader.ReadToEndAsync().Result);
                    return DataEngine.D<Good>(_logger, _conf["ConnectionString"] ?? "", "D_Goods", new SqlParameter[] { new SqlParameter("id", ppp.id) });
                }
                catch (Exception err)
                {
                    return new Result<Good>() { Success = false, Code = err.HResult, Description = err.Message };
                }
            }

        }
        [HttpPut]
        public Result<Good> Put()
        {
            try
            {
                using (var reader = new StreamReader(Request.Body))
                {
                    var ppp = JsonSerializer.Deserialize<Good>(reader.ReadToEndAsync().Result);

                    return DataEngine.IU<Good>(_logger, _conf["ConnectionString"] ?? "", "IU_Goods", new SqlParameter[] { new SqlParameter("id", ppp.id is null ? DBNull.Value : ppp.id), new SqlParameter("name", ppp.name) });
                }
            }
            catch (Exception err)
            {
                return new Result<Good>() { Success = false, Code = err.HResult, Description = err.Message };
            }
        }
    }
}
