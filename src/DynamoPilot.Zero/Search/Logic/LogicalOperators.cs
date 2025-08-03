using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;
using System.Linq;

namespace Search.Logic
{
    public static class LogicalOperators
    {
        [IsDesignScriptCompatible]
        public static PQueryBuilder ExcludeObjectState(PQueryBuilder builder, string objectState)
        {
            if (Enum.TryParse<ObjectState>(objectState, out var state))
            {
                builder.MustNot(ObjectFields.ObjectState.Be(state));
            }
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder ExcludeIsSecret(PQueryBuilder builder, bool isSecret)
        {
            builder.MustNot(ObjectFields.IsSecret.Be(isSecret));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder ExcludeBoolAttribute(PQueryBuilder builder, string attributeName, bool value)
        {
            builder.MustNot(AttributeFields.Bool(attributeName).Be(value));
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder AlternativeTypeIds(PQueryBuilder builder, int[] typeIds)
        {
            var terms = typeIds.Select(id => ObjectFields.TypeId.Be(id)).ToArray();
            builder.MustAnyOf(terms);
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder AlternativeTextSearch(PQueryBuilder builder, string[] searchTexts)
        {
            var terms = searchTexts.Select(text => ObjectFields.AllText.Be(text)).ToArray();
            builder.MustAnyOf(terms);
            return builder;
        }

        [IsDesignScriptCompatible]
        public static PQueryBuilder AlternativeStringAttribute(PQueryBuilder builder, string attributeName, string[] values)
        {
            var terms = values.Select(value => AttributeFields.String(attributeName).Be(value)).ToArray();
            builder.MustAnyOf(terms);
            return builder;
        }
    }
} 