using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5ChallengeWebApiDomain.Entities
{
    public class Permission
    {
        //Primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //Fields
        public required string EmployeeForename { get; set; }
        public required string EmployeeSurname { get; set; }
        [ForeignKey(nameof(PermissionTypeId))]
        public required int PermissionTypeId { get; set; }
        public DateTime PermissionDate { get; set; } = DateTime.Now;
        //Relationships
        public PermissionType? PermissionType { get; set; }
    }
}
