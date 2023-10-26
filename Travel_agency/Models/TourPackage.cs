namespace Travel_agency.Models
{
    public class TourPackage
    {
        public int TourPackageId { get; set; }
        public string? PackageName { get; set; }
        public int No_Of_Days { get; set; }
        public int No_Of_Persons { get; set; }
        public int MinPrice { get; set; }

        public int DestinationId { get; set; }

        public Destination? Destination { get; set; }
        

    }
}
