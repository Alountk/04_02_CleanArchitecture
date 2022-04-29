using System;
using System.Collections.Generic;

namespace Blog.Infrastructure.temp
{
    public partial class Schemaversion
    {
        public int Schemaversionsid { get; set; }
        public string Scriptname { get; set; } = null!;
        public DateTime Applied { get; set; }
    }
}
