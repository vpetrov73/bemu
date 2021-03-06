﻿//------------------------------------------------------------------------------
// <copyright project="BEmu_csh" file="IntradayTickRequest/IntradayTickElementData.cs" company="Jordan Robinson">
//     Copyright (c) 2013 Jordan Robinson. All rights reserved.
//
//     The use of this software is governed by the Microsoft Public License
//     which is included with this distribution.
// </copyright>
//------------------------------------------------------------------------------

namespace Bloomberglp.Blpapi.IntradayTickRequest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class IntradayTickElementData : Element
    {
        private readonly Dictionary<string, Element> _fields;

        public IntradayTickElementData(DateTime datetime, Types.Tuple3<string, double, int> values, bool includeConditionCodes)
        {
            this._fields = new Dictionary<string, Element>();

            Element elmTime = new IntradayTickElementDateTime(datetime);
            this._fields.Add(elmTime.Name.ToString(), elmTime);

            //TODO: This should actually be an enumeration, not a string
            Element elmType = new IntradayTickElementString("type", values.Item1);
            this._fields.Add(elmType.Name.ToString(), elmType);

            Element elmValue = new IntradayTickElementDouble("value", values.Item2);
            this._fields.Add(elmValue.Name.ToString(), elmValue);

            Element elmSize = new IntradayTickElementInt("size", values.Item3);
            this._fields.Add(elmSize.Name.ToString(), elmSize);

            if (includeConditionCodes)
            {
                Element elmConditionCodes = new IntradayTickElementString("conditionCodes", "R6,IS");
                this._fields.Add(elmConditionCodes.Name.ToString(), elmConditionCodes);
            }
        }

        public override IEnumerable<Element> Elements { get { return this._fields.Values; } }

        public override SchemaTypeDefinition TypeDefinition { get { return new SchemaTypeDefinition(this.Datatype, new Name("IntradayTickData")); } }
        public override Name Name { get { return new Name("tickData"); } }
        public override int NumValues { get { return 1; } }
        public override int NumElements { get { return this._fields.Count; } }
        public override bool IsComplexType { get { return true; } }
        public override bool IsArray { get { return false; } }
        public override bool IsNull { get { return false; } }

        public override object this[int index] { get { return null; } }
        public override Element GetElement(int index) { return this.Elements.Skip(index).First(); }
        public override Element GetElement(string name) { return this[name]; }
        public override Element this[string name] { get { return this._fields[name]; } }

        public override object this[string name, int index]
        {
            get
            {
                if (index == 0)
                    return this[name].GetValue();
                else
                    return base[name, index];
            }
        }

        public override int GetElementAsInt32(string name)
        {
            return this[name].GetValueAsInt32();
        }

        public override Datetime GetElementAsDatetime(string name)
        {
            return this[name].GetValueAsDatetime();
        }

        public override Datetime GetElementAsDate(string name)
        {
            return this[name].GetValueAsDate();
        }

        public override Datetime GetElementAsTime(string name)
        {
            return this[name].GetValueAsTime();
        }

        public override string GetElementAsString(string name)
        {
            return this[name].GetValueAsString();
        }

        public override float GetElementAsFloat32(string name)
        {
            return this[name].GetValueAsFloat32();
        }

        public override double GetElementAsFloat64(string name)
        {
            return this[name].GetValueAsFloat64();
        }

        public override long GetElementAsInt64(string name)
        {
            return this[name].GetValueAsInt64();
        }

        public override bool HasElement(string name, bool excludeNullElements = false)
        {
            return this._fields.ContainsKey(name);
        }

        internal override StringBuilder PrettyPrint(int tabIndent, bool surroundValueWithQuotes = false)
        {
            string tabs = Types.IndentType.Indent(tabIndent);
            StringBuilder result = new StringBuilder();

            result.AppendFormat("{0}tickData = {{{1}", tabs, Environment.NewLine);
            foreach (var item in this._fields.Values)
            {
                result.Append(item.PrettyPrint(tabIndent + 1));
            }
            result.AppendFormat("{0}}}{1}", tabs, Environment.NewLine);
            return result;
        }
    }
}
