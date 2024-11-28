using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Entities
{
    public class User : IdentityUser
    {
        /// <summary>
        /// Связка с тестами
        /// </summary>
        public ICollection<UserTestBind>? UserTestBinds { get; set; }
    }
}
