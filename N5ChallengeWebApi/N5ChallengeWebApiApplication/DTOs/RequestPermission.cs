using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5ChallengeWebApiApplication.DTOs
{
    public class RequestPermission
    {
        public required string EmployeeForename { get; set; }
        public required string EmployeeSurname { get; set; }
        public int PermissionTypeId { get; set; }
    }
}
