using System;
using System.Collections.Generic;
using System.Reflection;
using DRON.Exceptions;
using DRON.Parse;

namespace DRON.Deserialization
{
    internal class StringDeserializer : DeserializerBase<DronString>
    {
        #region Internal

        #region Constructors
        internal StringDeserializer(Deserializer deserializer)
            : base(deserializer) {}
        #endregion

        #region Member Methods
        internal override object Deserialize(
            DronString node,
            PropertyInfo property = null,
            object obj = null,
            Type _typeOverride = null,
            IReadOnlyList<DronAttribute> additionalAttributes = null
        )
        {
            if (property is null)
            {
                return node.Value;
            }
            var value = ConvertString(node.Value, property.PropertyType);
            if (obj is not null)
            {
                property.SetValue(obj, value);
            }
            return value;
        }
        #endregion

        #region Static Methods
        internal static object ConvertString(string value, Type stringType)
            => Type.GetTypeCode(stringType) switch
            {
                TypeCode.String => value,
                TypeCode.Object => new Guid(value), // Assume object is a Guid
                _ => throw new DronUnsupportedStringTypeException(stringType),
            };
        #endregion

        #endregion
    }
}