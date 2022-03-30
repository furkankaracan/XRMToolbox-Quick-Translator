using System;
using System.Collections.Generic;

namespace Quick_Translator
{
    class FormMetadata
    {
        public Dictionary<int, string> Descriptions { get; set; }
        public string Entity { get; set; }
        public Guid FormUniqueId { get; set; }
        public Guid Id { get; set; }
        public Dictionary<int, string> Names { get; set; }
    }
}
