namespace PetUci.Models
{
    public class Disease
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int idTreatment { get; set; }
        public Treatment treatment { get; set; }

    }
}
