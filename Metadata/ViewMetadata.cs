using System;
using System.Collections.Generic;

namespace Quick_Translator
{
   public class ViewMetadata
    {
        public Dictionary<int, string> Descriptions { get; set; }
        public string Entity { get; set; }
        public Guid Id { get; set; }
        public Dictionary<int, string> Names { get; set; }
        public int Type { get; set; }
    }
}
