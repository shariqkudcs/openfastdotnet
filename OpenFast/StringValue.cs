/*

The contents of this file are subject to the Mozilla Public License
Version 1.1 (the "License"); you may not use this file except in
compliance with the License. You may obtain a copy of the License at
http://www.mozilla.org/MPL/

Software distributed under the License is distributed on an "AS IS"
basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See the
License for the specific language governing rights and limitations
under the License.

The Original Code is OpenFAST.

The Initial Developer of the Original Code is The LaSalle Technology
Group, LLC.  Portions created by Shariq Muhammad
are Copyright (C) Shariq Muhammad. All Rights Reserved.

Contributor(s): Shariq Muhammad <shariq.muhammad@gmail.com>
                Yuri Astrakhan <FirstName><LastName>@gmail.com
*/
using System;
using System.Globalization;
using System.Text;
using OpenFAST.Error;

namespace OpenFAST
{
    public sealed class StringValue : ScalarValue, IEquatable<StringValue>
    {
        private readonly string _value;

        public StringValue(string value)
        {
            if (value == null) throw new ArgumentNullException("value");
            _value = value;
        }

        public override byte[] Bytes
        {
            get { return Encoding.UTF8.GetBytes(_value); }
        }

        public string Value
        {
            get { return _value; }
        }

        public override byte ToByte()
        {
            int i = ToInt();
            if (i > SByte.MaxValue || i < SByte.MinValue)
            {
                Global.ErrorHandler.OnError(null, RepError.NumericValueTooLarge,
                                            "The value '{0}' is too large to fit into a byte.", i);
                return 0;
            }
            return (byte) i;
        }

        public override short ToShort()
        {
            int i = ToInt();
            if (i > Int16.MaxValue || i < Int16.MinValue)
            {
                Global.ErrorHandler.OnError(null, RepError.NumericValueTooLarge,
                                            "The value '{0}' is too large to fit into a short.", i);
                return 0;
            }
            return (short) i;
        }

        public override int ToInt()
        {
            int result;
            if (Int32.TryParse(_value, out result))
                return result;

            Global.ErrorHandler.OnError(null, RepError.NumericValueTooLarge,
                                        "The value '{0}' is too large to fit into an int.", _value);
            return 0;
        }

        public override long ToLong()
        {
            long result;
            if (Int64.TryParse(_value, out result))
                return result;

            Global.ErrorHandler.OnError(null, RepError.NumericValueTooLarge,
                                        "The value '{0}' is too large to fit into a long.", _value);
            return 0;
        }

        public override double ToDouble()
        {
            double result;
            if (Double.TryParse(_value, out result))
                return result;

            Global.ErrorHandler.OnError(null, RepError.NumericValueTooLarge,
                                        "The value'{0}' is too large to fit into a double.", _value);
            return 0.0;
        }

        public override Decimal ToBigDecimal()
        {
            return Decimal.Parse(_value, NumberStyles.Any);
        }

        public override string ToString()
        {
            return _value;
        }

        public override bool EqualsValue(string defaultValue)
        {
            return _value.Equals(defaultValue);
        }

        #region Equals

        public bool Equals(StringValue other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other._value, _value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            var t = obj as StringValue;
            if (t == null) return false;
            return t._value.Equals(_value);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        #endregion
    }
}