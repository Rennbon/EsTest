using System;
using System.Collections.Generic;
using System.Text;
using Nest;
using Newtonsoft.Json;

namespace EsEntity
{
    public class EntityBase
    {
        [Keyword(Name = "appid")]
        public string AppID { set; get; }
        [Boolean(Name = "isdel")]
        public bool IsDeleted { get; set; }
        [Date(Name = "utime", Format = "yyyy-MM-dd HH:mm:ss")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime UpdateTime { get; set; }
        [Date(Name = "ctime", Format = "yyyy-MM-dd HH:mm:ss")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime CreateTime { get; set; }
        [Keyword(Name = "pid")]
        public string ProjectId { set; get; }
        [Keyword(Name = "caid")]
        public string CreateAccountID { get; set; }
    }
}
