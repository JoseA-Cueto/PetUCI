namespace PetUci.Models
{
    public class Treatment
    {   
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int idDisease { get; set; }
        public Disease disease { get; set; }
    }
}
