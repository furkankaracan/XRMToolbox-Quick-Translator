﻿using System;
using System.Collections.Generic;

namespace Quick_Translator
{
    public class FormSectionMetadata
    {
        public Dictionary<int, string> Descriptions { get; set; }
        public string Entity { get; set; }
        public string Form { get; set; }
        public Guid FormId { get; set; }
        public Guid FormUniqueId { get; set; }
        public Guid Id { get; set; }
        public Dictionary<int, string> Names { get; set; }
        public string Tab { get; set; }
    }
}
