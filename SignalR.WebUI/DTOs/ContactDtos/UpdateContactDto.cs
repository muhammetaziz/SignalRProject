namespace SignalR.WebUI.DTOs.ContactDtos
{
    public class UpdateContactDto
    {
        public int ContactID { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string ContactEmail { get; set; }
        public string FooterDescription { get; set; }
    }
}
