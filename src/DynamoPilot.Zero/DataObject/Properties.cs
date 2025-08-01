using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DataObject
{
    public static class Properties
    {
        [IsDesignScriptCompatible]
        public static Guid GetId(PDataObject dataObject)
        {
            return dataObject.Id;
        }

        [IsDesignScriptCompatible]
        public static Guid GetParentId(PDataObject dataObject)
        {
            return dataObject.ParentId;
        }

        [IsDesignScriptCompatible]
        public static DateTime GetCreated(PDataObject dataObject)
        {
            return dataObject.Created;
        }

        [IsDesignScriptCompatible]
        public static IDictionary<string, object> GetAttributes(PDataObject dataObject)
        {
            return dataObject.Attributes;
        }

        [IsDesignScriptCompatible]
        public static string GetDisplayName(PDataObject dataObject)
        {
            return dataObject.DisplayName;
        }

        [IsDesignScriptCompatible]
        public static PType GetType(PDataObject dataObject)
        {
            return dataObject.Type;
        }

        [IsDesignScriptCompatible]
        public static PPerson GetCreator(PDataObject dataObject)
        {
            return dataObject.Creator;
        }

        [IsDesignScriptCompatible]
        public static ReadOnlyCollection<Guid> GetChildren(PDataObject dataObject)
        {
            return dataObject.Children;
        }

        [IsDesignScriptCompatible]
        public static ReadOnlyCollection<PRelation> GetRelations(PDataObject dataObject)
        {
            return dataObject.Relations;
        }

        [IsDesignScriptCompatible]
        public static ReadOnlyCollection<Guid> GetRelatedSourceFiles(PDataObject dataObject)
        {
            return dataObject.RelatedSourceFiles;
        }

        [IsDesignScriptCompatible]
        public static IDictionary<Guid, int> GetTypesByChildren(PDataObject dataObject)
        {
            return dataObject.TypesByChildren;
        }

        [IsDesignScriptCompatible]
        public static DataState GetState(PDataObject dataObject)
        {
            return dataObject.State;
        }

        [IsDesignScriptCompatible]
        public static PStateInfo GetObjectStateInfo(PDataObject dataObject)
        {
            return dataObject.ObjectStateInfo;
        }

        [IsDesignScriptCompatible]
        public static SynchronizationState GetSynchronizationState(PDataObject dataObject)
        {
            return dataObject.SynchronizationState;
        }

        [IsDesignScriptCompatible]
        public static ReadOnlyCollection<PFile> GetFiles(PDataObject dataObject)
        {
            return dataObject.Files;
        }

        [IsDesignScriptCompatible]
        public static ReadOnlyCollection<PAccessRecord> GetAccess2(PDataObject dataObject)
        {
            return dataObject.Access2;
        }

        [IsDesignScriptCompatible]
        public static bool GetIsSecret(PDataObject dataObject)
        {
            return dataObject.IsSecret;
        }

        [IsDesignScriptCompatible]
        public static PFilesSnapshot GetActualFileSnapshot(PDataObject dataObject)
        {
            return dataObject.ActualFileSnapshot;
        }

        [IsDesignScriptCompatible]
        public static ReadOnlyCollection<PFilesSnapshot> GetPreviousFileSnapshots(PDataObject dataObject)
        {
            return dataObject.PreviousFileSnapshots;
        }

        [IsDesignScriptCompatible]
        public static ReadOnlyCollection<int> GetSubscribers(PDataObject dataObject)
        {
            return dataObject.Subscribers;
        }
    }
}

