﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEmu3.MarketDataRequest
{
    public class ElementMarketString : Element
    {
        private readonly string _name, _value;

        internal ElementMarketString(string name, string value)
        {
            this._name = name;
            this._value = value;
        }

        public override Name Name { get { return new Name(this._name); } }
        public override int NumValues { get { return 1; } }
        public override int NumElements { get { return 0; } }
        public override bool IsNull { get { return false; } }
        public override bool IsArray { get { return false; } }
        public override bool IsComplexType { get { return false; } }

        public override object this[int index]
        {
            get
            {
                if (index == 0)
                    return this._value;
                else
                    throw new IndexOutOfRangeException();
            }
        }

        internal override StringBuilder PrettyPrint(int tabIndent)
        {
            return base.PrettyPrintHelper(tabIndent, this._value);
        }

        public override object GetValue()
        {
            return this._value;
        }

        public override string GetValueAsString()
        {
            return this._value;
        }
    }
}
