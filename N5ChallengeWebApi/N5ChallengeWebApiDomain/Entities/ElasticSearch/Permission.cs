namespace N5ChallengeWebApiDomain.Entities.ElasticSearch
{
    public class Permission
    {
        public int Id { get; set; }
        public required string EmployeeForename { get; set; }
        public required string EmployeeSurname { get; set; }
        public required int PermissionTypeId { get; set; }
        public DateTime PermissionDate { get; set; }
    }
}
