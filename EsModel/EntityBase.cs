﻿using System;
using System.Collections.Generic;
using System.Text;
using Nest;
using Newtonsoft.Json;

namespace EsEntity
{
    public class EntityBase : ESFramework.IESEntity
    {
        [Keyword]
        [JsonProperty("appid")]
        public string AppId { set; get; }
        [Boolean]
        [JsonProperty("isdel")]
        public bool IsDeleted { get; set; }
        [Date(Format = "yyyy-MM-dd HH:mm:ss.SSS")]
        [JsonProperty("utime")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime UpdateTime { get; set; }
        [Date(Format = "yyyy-MM-dd HH:mm:ss.SSS")]
        [JsonProperty("ctime")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime CreateTime { get; set; }
        [Keyword]
        [JsonProperty("pid")]
        public string ProjectId { set; get; }
        [Keyword]
        [JsonProperty("caid")]
        public string CreateAccountId { get; set; }
    }
}
