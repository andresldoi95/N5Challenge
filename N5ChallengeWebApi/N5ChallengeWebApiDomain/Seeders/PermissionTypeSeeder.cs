using N5ChallengeWebApiDomain.Entities;

namespace N5ChallengeWebApiDomain.Seeders
{
    public class PermissionTypeSeeder
    {
        public void Seed(N5ChallengeDBContext context)
        {
            if (!context.PermissionTypes.Any())
            {
                context.PermissionTypes.AddRange(
                    new PermissionType
                    {
                        Description = "Read"
                    },
                    new PermissionType
                    {
                        Description = "Write"
                    },
                    new PermissionType
                    {
                        Description = "Execute"
                    }                                                                    
               );
               context.SaveChanges();
            }
        }
    }
}
