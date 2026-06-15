namespace GraduationProject.DTOS
{
    public class AdoptionRequestToReturnDTO
    {
        public int Id { get; set; }
        public string AnimalName { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
