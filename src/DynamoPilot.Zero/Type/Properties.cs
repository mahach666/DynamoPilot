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
        public static int GetId(PType pilotType)
        {
            return pilotType.Id;
        }

        [IsDesignScriptCompatible]
        public static string GetName(PType pilotType)
        {
            return pilotType.Name;
        }

        [IsDesignScriptCompatible]
        public static string GetTitle(PType pilotType)
        {
            return pilotType.Title;
        }

        [IsDesignScriptCompatible]
        public static int GetSort(PType pilotType)
        {
            return pilotType.Sort;
        }

        [IsDesignScriptCompatible]
        public static bool GetHasFiles(PType pilotType)
        {
            return pilotType.HasFiles;
        }

        [IsDesignScriptCompatible]
        public static ReadOnlyCollection<int> GetChildren(PType pilotType)
        {
            return pilotType.Children;
        }

        [IsDesignScriptCompatible]
        public static ReadOnlyCollection<PAttribute> GetAttributes(PType pilotType)
        {
            return pilotType.Attributes;
        }

        [IsDesignScriptCompatible]
        public static IEnumerable<PAttribute> GetDisplayAttributes(PType pilotType)
        {
            return pilotType.DisplayAttributes;
        }

        [IsDesignScriptCompatible]
        public static byte[] GetSvgIcon(PType pilotType)
        {
            return pilotType.SvgIcon;
        }

        [IsDesignScriptCompatible]
        public static bool GetIsMountable(PType pilotType)
        {
            return pilotType.IsMountable;
        }

        [IsDesignScriptCompatible]
        public static TypeKind GetKind(PType pilotType)
        {
            return pilotType.Kind;
        }

        [IsDesignScriptCompatible]
        public static bool GetIsDeleted(PType pilotType)
        {
            return pilotType.IsDeleted;
        }

        [IsDesignScriptCompatible]
        public static bool GetIsService(PType pilotType)
        {
            return pilotType.IsService;
        }

        [IsDesignScriptCompatible]
        public static bool GetIsProject(PType pilotType)
        {
            return pilotType.IsProject;
        }
    }
}

