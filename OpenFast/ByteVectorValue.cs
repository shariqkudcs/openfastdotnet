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
using System.Text;
using OpenFAST.Utility;

namespace OpenFAST
{
    public sealed class ByteVectorValue : ScalarValue, IEquatable<ByteVectorValue>
    {
        public static readonly ScalarValue EmptyBytes = new ByteVectorValue(ByteUtil.EmptyByteArray);

        private readonly ArraySegment<byte> _value;

        public ByteVectorValue(byte[] value)
            : this(new ArraySegment<byte>(value))
        {
        }

        public ByteVectorValue(ArraySegment<byte> value)
        {
            _value = value;
        }

        public override byte[] Bytes
        {
            get { return _value.Array; }
        }

        public byte[] Value
        {
            get { return _value.Array; }
        }

        public override string ToString()
        {
            return Encoding.ASCII.GetString(_value.Array, _value.Offset, _value.Count);
        }

        #region Equals (optimized for empty parent class)

        public bool Equals(ByteVectorValue other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Util.ArraySegmentEquals(other._value, _value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            var t = obj as ByteVectorValue;
            if (t==null) return false;
            return Util.ArraySegmentEquals(t._value,_value);
        }

        public override int GetHashCode()
        {
            return Util.GetValTypeCollectionHashCode(_value);
        }

        #endregion
    }
}