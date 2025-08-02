using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using System;

namespace Search.Filters
{
    public static class AttributeFilters
    {
        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterByStringAttribute(IQueryBuilder builder, string attributeName, string value)
        {
            builder.Must(AttributeFields.String(attributeName).Be(value));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterByDateTimeAttributeRange(IQueryBuilder builder, string attributeName, DateTime fromDate, DateTime toDate)
        {
            builder.Must(AttributeFields.DateTime(attributeName).BeInRange(fromDate.ToUniversalTime(), toDate.ToUniversalTime()));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterByDoubleAttribute(IQueryBuilder builder, string attributeName, double value)
        {
            builder.Must(AttributeFields.Double(attributeName).Be(value));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterByDoubleAttributeMultiple(IQueryBuilder builder, string attributeName, double[] values)
        {
            builder.Must(AttributeFields.Double(attributeName).BeAnyOf(values));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterByDoubleAttributeRange(IQueryBuilder builder, string attributeName, double fromValue, double toValue)
        {
            builder.Must(AttributeFields.Double(attributeName).BeInRange(fromValue, toValue));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterByIntegerAttribute(IQueryBuilder builder, string attributeName, int value)
        {
            builder.Must(AttributeFields.Integer(attributeName).Be(value));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterByIntegerAttributeMultiple(IQueryBuilder builder, string attributeName, long[] values)
        {
            builder.Must(AttributeFields.Integer(attributeName).BeAnyOf(values));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterByIntegerAttributeRange(IQueryBuilder builder, string attributeName, int fromValue, int toValue)
        {
            builder.Must(AttributeFields.Integer(attributeName).BeInRange(fromValue, toValue));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder FilterByBoolAttribute(IQueryBuilder builder, string attributeName, bool value)
        {
            builder.Must(AttributeFields.Bool(attributeName).Be(value));
            return builder;
        }
    }
} 