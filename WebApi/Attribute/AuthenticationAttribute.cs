using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace WebApi.Attribute
{
    public class AuthenticationAttribute : AuthorizeFilter
    {
        public AuthenticationAttribute() 
        { }

        public AuthenticationAttribute(AuthorizationPolicy policy) : base(policy)
        {
        }

        public AuthenticationAttribute(IEnumerable<IAuthorizeData> authorizeData) : base(authorizeData)
        {
        }

        public AuthenticationAttribute(string policy) : base(policy)
        {
        }

        public AuthenticationAttribute(IAuthorizationPolicyProvider policyProvider, IEnumerable<IAuthorizeData> authorizeData) : base(policyProvider, authorizeData)
        {
        }
    }
}
