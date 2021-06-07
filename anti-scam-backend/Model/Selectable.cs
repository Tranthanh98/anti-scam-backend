﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Model
{
    public class Selectable
    {
        public Selectable(string value, string label)
        {
            Value = value;
            Label = label;
        }
        public Selectable() { }
        public string Value { get; set; }
        public string Label { get; set; }
    }
    public class Selectable<T> : Selectable
    {
        public Selectable() : base() { }
        public Selectable(string value, string label) : base(value, label) { }
        public T Data { get; set; }
    }
}
