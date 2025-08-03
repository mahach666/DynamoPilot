using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;

namespace Search.Filters
{
    public static class AttributeFilters
    {
        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByStringAttribute(PQueryBuilder builder, string attributeName, string value)
        {
            builder.Must(AttributeFields.String(attributeName).Be(value));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByDateTimeAttributeRange(PQueryBuilder builder, string attributeName, DateTime fromDate, DateTime toDate)
        {
            builder.Must(AttributeFields.DateTime(attributeName).BeInRange(fromDate.ToUniversalTime(), toDate.ToUniversalTime()));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByDoubleAttribute(PQueryBuilder builder, string attributeName, double value)
        {
            builder.Must(AttributeFields.Double(attributeName).Be(value));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByDoubleAttributeMultiple(PQueryBuilder builder, string attributeName, double[] values)
        {
            builder.Must(AttributeFields.Double(attributeName).BeAnyOf(values));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByDoubleAttributeRange(PQueryBuilder builder, string attributeName, double fromValue, double toValue)
        {
            builder.Must(AttributeFields.Double(attributeName).BeInRange(fromValue, toValue));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByIntegerAttribute(PQueryBuilder builder, string attributeName, int value)
        {
            builder.Must(AttributeFields.Integer(attributeName).Be(value));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByIntegerAttributeMultiple(PQueryBuilder builder, string attributeName, long[] values)
        {
            builder.Must(AttributeFields.Integer(attributeName).BeAnyOf(values));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByIntegerAttributeRange(PQueryBuilder builder, string attributeName, int fromValue, int toValue)
        {
            builder.Must(AttributeFields.Integer(attributeName).BeInRange(fromValue, toValue));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder FilterByBoolAttribute(PQueryBuilder builder, string attributeName, bool value)
        {
            builder.Must(AttributeFields.Bool(attributeName).Be(value));
            return builder;
        }
    }
} 