using Microsoft.AspNetCore.Identity;

namespace Backend_Final.Helper
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresUpper),
                Description = "Senhas devem conter ao menos um caracter em caixa alta ('A'-'Z')."
            };
        }
    }
}