using System.Collections.Generic;

namespace VSDev.Api.DTOs
{

    public class LoginResponseViewModel
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserTokenViewModel User { get; set; }
    }

    public class UserTokenViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<ClaimViewModel> Claims { get; set; }
    }

    public class ClaimViewModel
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }

}
