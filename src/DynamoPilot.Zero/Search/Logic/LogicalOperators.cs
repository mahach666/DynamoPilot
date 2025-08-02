using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using System;
using System.Linq;

namespace Search.Logic
{
    public static class LogicalOperators
    {
        [IsDesignScriptCompatible]
        public static IQueryBuilder ExcludeObjectState(IQueryBuilder builder, string objectState)
        {
            if (Enum.TryParse<ObjectState>(objectState, out var state))
            {
                builder.MustNot(ObjectFields.ObjectState.Be(state));
            }
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder ExcludeIsSecret(IQueryBuilder builder, bool isSecret)
        {
            builder.MustNot(ObjectFields.IsSecret.Be(isSecret));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder ExcludeBoolAttribute(IQueryBuilder builder, string attributeName, bool value)
        {
            builder.MustNot(AttributeFields.Bool(attributeName).Be(value));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder AlternativeTypeIds(IQueryBuilder builder, int[] typeIds)
        {
            var terms = typeIds.Select(id => ObjectFields.TypeId.Be(id)).ToArray();
            builder.MustAnyOf(terms);
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder AlternativeTextSearch(IQueryBuilder builder, string[] searchTexts)
        {
            var terms = searchTexts.Select(text => ObjectFields.AllText.Be(text)).ToArray();
            builder.MustAnyOf(terms);
            return builder;
        }

        [IsDesignScriptCompatible]
        public static IQueryBuilder AlternativeStringAttribute(IQueryBuilder builder, string attributeName, string[] values)
        {
            var terms = values.Select(value => AttributeFields.String(attributeName).Be(value)).ToArray();
            builder.MustAnyOf(terms);
            return builder;
        }
    }
} 