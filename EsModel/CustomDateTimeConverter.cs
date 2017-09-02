using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace EsEntity
{
    public class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter()
        {
            DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        }
    }
}
