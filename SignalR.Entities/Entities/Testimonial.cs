namespace SignalR.EntityLayer.Entities
{
    public class Testimonial
    {
        public int TestimonialID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
        public bool Status { get; set; }

    }
}
