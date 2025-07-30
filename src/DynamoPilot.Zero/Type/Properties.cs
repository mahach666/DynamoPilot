using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Type
{
    public static class Properties
    {
        [IsDesignScriptCompatible]
        public static int GetId(PilotType pilotType)
        {
            return pilotType.Id;
        }

        [IsDesignScriptCompatible]
        public static string GetName(PilotType pilotType)
        {
            return pilotType.Name;
        }

        [IsDesignScriptCompatible]
        public static string GetTitle(PilotType pilotType)
        {
            return pilotType.Title;
        }

        [IsDesignScriptCompatible]
        public static int GetSort(PilotType pilotType)
        {
            return pilotType.Sort;
        }

        [IsDesignScriptCompatible]
        public static bool GetHasFiles(PilotType pilotType)
        {
            return pilotType.HasFiles;
        }

        [IsDesignScriptCompatible]
        public static ReadOnlyCollection<int> GetChildren(PilotType pilotType)
        {
            return pilotType.Children;
        }

        [IsDesignScriptCompatible]
        public static ReadOnlyCollection<PilotAttribute> GetAttributes(PilotType pilotType)
        {
            return pilotType.Attributes;
        }

        [IsDesignScriptCompatible]
        public static IEnumerable<PilotAttribute> GetDisplayAttributes(PilotType pilotType)
        {
            return pilotType.DisplayAttributes;
        }

        [IsDesignScriptCompatible]
        public static byte[] GetSvgIcon(PilotType pilotType)
        {
            return pilotType.SvgIcon;
        }

        [IsDesignScriptCompatible]
        public static bool GetIsMountable(PilotType pilotType)
        {
            return pilotType.IsMountable;
        }

        [IsDesignScriptCompatible]
        public static TypeKind GetKind(PilotType pilotType)
        {
            return pilotType.Kind;
        }

        [IsDesignScriptCompatible]
        public static bool GetIsDeleted(PilotType pilotType)
        {
            return pilotType.IsDeleted;
        }

        [IsDesignScriptCompatible]
        public static bool GetIsService(PilotType pilotType)
        {
            return pilotType.IsService;
        }

        [IsDesignScriptCompatible]
        public static bool GetIsProject(PilotType pilotType)
        {
            return pilotType.IsProject;
        }
    }
}

