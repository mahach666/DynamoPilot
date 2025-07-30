using Ascon.Pilot.SDK;
using Dynamo.Graph.Nodes;
using DynamoPilot.Data.Wrappers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


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
        public static List<int> GetId(List<PilotType> pilotTypes)
        {
            return pilotTypes.Select(t=>t.Id).ToList();
        }

        [IsDesignScriptCompatible]
        public static string GetName(PilotType pilotType)
        {
            return pilotType.Name;
        }

        [IsDesignScriptCompatible]
        public static List<string> GetName(List<PilotType> pilotTypes)
        {
            return pilotTypes.Select(t => t.Name).ToList();
        }

        [IsDesignScriptCompatible]
        public static string GetTitle(PilotType pilotType)
        {
            return pilotType.Title;
        }

        [IsDesignScriptCompatible]
        public static List<string> GetTitle(List<PilotType> pilotTypes)
        {
            return pilotTypes.Select(t => t.Title).ToList();
        }

        [IsDesignScriptCompatible]
        public static int GetSort(PilotType pilotType)
        {
            return pilotType.Sort;
        }

        [IsDesignScriptCompatible]
        public static List<int> GetSort(List<PilotType> pilotTypes)
        {
            return pilotTypes.Select(t => t.Sort).ToList();
        }

        [IsDesignScriptCompatible]
        public static bool GetHasFiles(PilotType pilotType)
        {
            return pilotType.HasFiles;
        }

        [IsDesignScriptCompatible]
        public static List<bool> GetHasFiles(List<PilotType> pilotTypes)
        {
            return pilotTypes.Select(t => t.HasFiles).ToList();
        }

        [IsDesignScriptCompatible]
        public static ReadOnlyCollection<int> GetChildren(PilotType pilotType)
        {
            return pilotType.Children;
        }

        [IsDesignScriptCompatible]
        public static List<ReadOnlyCollection<int>> GetChildren(List<PilotType> pilotTypes)
        {
            return pilotTypes.Select(t => t.Children).ToList();
        }

        [IsDesignScriptCompatible]
        public static ReadOnlyCollection<PilotAttribute> GetAttributes(PilotType pilotType)
        {
            return pilotType.Attributes;
        }

        [IsDesignScriptCompatible]
        public static List<ReadOnlyCollection<PilotAttribute>> GetAttributes(List<PilotType> pilotTypes)
        {
            return pilotTypes.Select(t => t.Attributes).ToList();
        }

        [IsDesignScriptCompatible]
        public static IEnumerable<PilotAttribute> GetDisplayAttributes(PilotType pilotType)
        {
            return pilotType.DisplayAttributes;
        }

        [IsDesignScriptCompatible]
        public static List<IEnumerable<PilotAttribute>> GetDisplayAttributes(List<PilotType> pilotTypes)
        {
            return pilotTypes.Select(t => t.DisplayAttributes).ToList();
        }

        [IsDesignScriptCompatible]
        public static byte[] GetSvgIcon(PilotType pilotType)
        {
            return pilotType.SvgIcon;
        }

        [IsDesignScriptCompatible]
        public static List<byte[]> GetSvgIcon(List<PilotType> pilotTypes)
        {
            return pilotTypes.Select(t => t.SvgIcon).ToList();
        }

        [IsDesignScriptCompatible]
        public static bool GetIsMountable(PilotType pilotType)
        {
            return pilotType.IsMountable;
        }

        [IsDesignScriptCompatible]
        public static List<bool> GetIsMountable(List<PilotType> pilotTypes)
        {
            return pilotTypes.Select(t => t.IsMountable).ToList();
        }

        [IsDesignScriptCompatible]
        public static TypeKind GetKind(PilotType pilotType)
        {
            return pilotType.Kind;
        }

        [IsDesignScriptCompatible]
        public static List<TypeKind> GetKind(List<PilotType> pilotTypes)
        {
            return pilotTypes.Select(t => t.Kind).ToList();
        }

        [IsDesignScriptCompatible]
        public static bool GetIsDeleted(PilotType pilotType)
        {
            return pilotType.IsDeleted;
        }

        [IsDesignScriptCompatible]
        public static List<bool> GetIsDeleted(List<PilotType> pilotTypes)
        {
            return pilotTypes.Select(t => t.IsDeleted).ToList();
        }

        [IsDesignScriptCompatible]
        public static bool GetIsService(PilotType pilotType)
        {
            return pilotType.IsService;
        }

        [IsDesignScriptCompatible]
        public static List<bool> GetIsService(List<PilotType> pilotTypes)
        {
            return pilotTypes.Select(t => t.IsService).ToList();
        }

        [IsDesignScriptCompatible]
        public static bool GetIsProject(PilotType pilotType)
        {
            return pilotType.IsProject;
        }

        [IsDesignScriptCompatible]
        public static List<bool> GetIsProject(List<PilotType> pilotTypes)
        {
            return pilotTypes.Select(t => t.IsProject).ToList();
        }
    }
}

