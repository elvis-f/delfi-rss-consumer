using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Catchsmart.Areas.Identity.Data;

// Add profile data for application users by adding properties to the CatchsmartUser class
public class CatchsmartUser : IdentityUser
{
    [PersonalData]
    public string Name { get; set; }
    [PersonalData]
    public string Category { get; set; } = "delfi";
    [PersonalData]
    public int RecordCount { get; set; } = 10;
    
    public string AvatarId { get; set; }
}

