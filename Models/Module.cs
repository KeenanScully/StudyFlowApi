namespace StudyFlowApi.Models
{
    public class Module
    {
        public int Id { get; set; } 

        public string Name { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

        public string Lecturer { get; set; } = string.Empty;

        public string Colour { get; set; } = string.Empty;
    }
}
