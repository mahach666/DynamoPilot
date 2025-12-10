namespace ServerAdmin.Models
{
    /// <summary>
    /// DTO для возврата количества резерваций по продукту.
    /// </summary>
    public class ReservationCountInfo
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}

