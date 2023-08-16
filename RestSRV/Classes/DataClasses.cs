using System.Net;
using System.Numerics;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Data;

namespace RestSRV.Classes
{
    public class Result
    {
        public bool Success { get; set; } = true;
        public string Description { get; set; } = "";
        public int Code { get; set; } = 0;
        public DataTable? Table { get; set; } = new DataTable();
        public Result setError(int code, string description)
        {
            this.Code = code;
            this.Description = description;
            this.Success = false;
            return this;
        }
        public Result setSucces()
        {
            this.Code = 0;
            this.Description = "";
            this.Success = true;
            return this;
        }
    }
    public class Result<Z>
    {
        public bool             Success     { get; set; } = true;
        public string           Description { get; set; } = "";
        public int              Code        { get; set; } = 0;
        public List<Z>          Payload     { get; set; } = new List<Z>();

        public Result<Z>        setError(int code, string description)
        {
            this.Code = code;
            this.Description = description;
            this.Success = false;
            return this;
        }
        public Result<Z> setSucces()
        {
            this.Code = 0;
            this.Description = "";
            this.Success = true;
            return this;
        }
    }
    public class tstDataBase
    {
        public int? id { set; get; }
    }
    public class Good: tstDataBase
    {
        public required string  name    { set; get; }
    }

    public class Pharm :tstDataBase
    {
        public required string  name    { set; get; }
        public required string  address { set; get; }
        public required string  phone   { set; get; }
    }

    public class Store:tstDataBase
    {
        public required int     pharmID { set; get; }
        public required string  name    { set; get; }
    }

    public class Lot: tstDataBase
    {
        public required int pharmID     { set; get; }
        public required int storeId     { set; get; }
        public required int goodId      { set; get; }
        public required int q           { set; get; }
    }

    public class GoodByPharm
    {
        public required string  name { set; get; }
        public required int     N { set; get; }
    }
}