using N5ChallengeWebApiDomain.Entities;
namespace N5ChallengeWebApiApplication.DTOs
{
    public class PermissionView
    {
        public int Id { get; set; }
        public required string EmployeeForename { get; set; }
        public required string EmployeeSurname { get; set; }
        public required PermissionType PermissionType { get; set; }
        public DateTime PermissionDate { get; set; }
    }
}
