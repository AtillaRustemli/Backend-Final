namespace Backend_Final.Models
{
    public class SliderImage
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public bool IsMain { get; set; }
        public int SliderId { get; set; }
        public Slider Slider { get; set; }
    }
}
