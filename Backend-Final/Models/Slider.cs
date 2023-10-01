namespace Backend_Final.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string Title{ get; set; }
        public string Definition{ get; set; }
        public string Description{ get; set; }
        public List<SliderImage> SliderImgae { get; set; }
    }
}
