using System.Security.Claims;

namespace TestCommon.Constants;

public static class ClaimConstants
{
    public static Claim AdminRole = new Claim(ClaimTypes.Role, "admin");
    public static Claim StudentRole = new Claim(ClaimTypes.Role, "student");
    public static Claim Id(Guid id) => new Claim("sub", id.ToString());

}