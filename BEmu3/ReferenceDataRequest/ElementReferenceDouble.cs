﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEmu3.ReferenceDataRequest
{
    public class ElementReferenceDouble : Element
    {
        private readonly double _value;
        private readonly string _name;

        internal ElementReferenceDouble(string name, double value)
        {
            this._name = name;
            this._value = value;
        }

        public override Name Name { get { return new Name(this._name); } }
        public override int NumValues { get { return 1; } }
        public override int NumElements { get { return 0; } }
        public override bool IsArray { get { return false; } }
        public override bool IsComplexType { get { return base.IsComplexType; } }

        internal override StringBuilder PrettyPrint(int tabIndent)
        {
            return base.PrettyPrintHelper(tabIndent, this._value.ToString());
        }

        public override object GetValue()
        {
            return this._value;
        }

        public override double GetValueAsFloat64()
        {
            return this._value;
        }

        public override int GetValueAsInt32()
        {
            return (int)this._value;
        }

        public override long GetValueAsInt64()
        {
            return (long)this._value;
        }
    }
}
