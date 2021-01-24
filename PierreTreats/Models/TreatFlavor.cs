namespace PierreTreats.Models
{
    public class TreatFlavor
    {
        public int PierreTreatId { get; set; }
        public int TreatId { get; set; }
         public int FlavorId { get; set; }
        public Treat Treat { get; set; }
        public Flavor Flavor { get; set; }
    }
}