using DynamoPilot.Data.Wrappers;

namespace DynamoPilot.Data
{
    public static class StaticMetadata
    {
        public static PObjectsRepository ObjectsRepository { get; set; }
        public static PObjectModifier ObjectModifier { get; set; }
        public static PSearchService SearchService { get; set; }
        public static PPilotDialogService PilotDialogService { get; set; }
        public static PMessagesRepository MessagesRepository { get; set; }
        public static PFileProvider FileProvider { get; set; }
}
}
