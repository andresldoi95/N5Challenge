namespace N5ChallengeWebApiApplication.DTOs
{
    public class ModifyPermission
    {
        public required int Id { get; set; }
        public required string EmployeeForename { get; set; }
        public required string EmployeeSurname { get; set; }
        public required int PermissionTypeId { get; set; }
    }
}
