﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEmu.HistoricalDataRequest
{
    internal class RequestHistoricElementStringArray : Element
    {
        private readonly string _elementName;
        private readonly List<string> _values;

        internal RequestHistoricElementStringArray(string elementName)
        {
            this._elementName = elementName;
            this._values = new List<string>();
        }

        public override int NumElements { get { return 0; } }
        public override int NumValues { get { return this._values.Count; } }
        public override Name Name { get { return new Name(this._elementName); } }
        public override bool IsArray { get { return true; } }
        public override bool IsComplexType { get { return false; } }
        public override bool IsNull { get { return false; } }

        internal void AddValue(string value)
        {
            this._values.Add(value);
        }

        internal List<string> Values { get { return this._values; } }

        internal override StringBuilder PrettyPrint(int tabIndent)
        {
            string tabs = Types.IndentType.Indent(tabIndent);
            StringBuilder result = new StringBuilder();

            result.AppendFormat("{0}{1}[] = {{{2}", tabs, this.Name, Environment.NewLine);

            string secs = string.Join(", ", this._values);
            result.AppendFormat("{0}{1}{2}{3}", tabs, Types.IndentType.TAB, secs, Environment.NewLine);

            result.AppendFormat("{0}}}{1}", tabs, Environment.NewLine);

            return result;
        }
    }
}