using System;
using System.Collections.Generic;

namespace Blog.Core.Entities
{
    public partial class Schemaversion
    {
        public int Schemaversionsid { get; set; }
        public string Scriptname { get; set; } = null!;
        public DateTime Applied { get; set; }
    }
}
