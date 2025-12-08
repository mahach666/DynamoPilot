#if NETSTANDARD2_0
using System;

namespace Autodesk.DesignScript.Runtime
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
    public sealed class IsDesignScriptCompatibleAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
    public sealed class IsVisibleInDynamoLibraryAttribute : Attribute
    {
        public bool Visible { get; }

        public IsVisibleInDynamoLibraryAttribute(bool visible = true)
        {
            Visible = visible;
        }
    }
}

namespace Dynamo.Graph.Nodes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class NodeCategoryAttribute : Attribute
    {
        public NodeCategoryAttribute(string category) { }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class NodeDescriptionAttribute : Attribute
    {
        public NodeDescriptionAttribute(string description) { }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class NodeNameAttribute : Attribute
    {
        public NodeNameAttribute(string name) { }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class InPortNamesAttribute : Attribute
    {
        public InPortNamesAttribute(params string[] names) { }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class InPortTypesAttribute : Attribute
    {
        public InPortTypesAttribute(params string[] types) { }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class InPortDescriptionsAttribute : Attribute
    {
        public InPortDescriptionsAttribute(params string[] descriptions) { }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class OutPortNamesAttribute : Attribute
    {
        public OutPortNamesAttribute(params string[] names) { }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class OutPortTypesAttribute : Attribute
    {
        public OutPortTypesAttribute(params string[] types) { }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class OutPortDescriptionsAttribute : Attribute
    {
        public OutPortDescriptionsAttribute(params string[] descriptions) { }
    }
}
#endif

