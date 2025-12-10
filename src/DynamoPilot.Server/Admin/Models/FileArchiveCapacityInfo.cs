namespace ServerAdmin.Models
{
    /// <summary>
    /// DTO для отображения ёмкости файлового архива.
    /// </summary>
    public class FileArchiveCapacityInfo
    {
        public string Id { get; set; }
        public long Capacity { get; set; }
    }
}

