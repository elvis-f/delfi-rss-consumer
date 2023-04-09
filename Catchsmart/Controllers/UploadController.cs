using System.Net;
using System.Text;
using System.Web.Http.Results;
using Azure.Core;

namespace Catchsmart.Controllers;

public class UploadController : Controller
{
    private readonly CatchsmartIdentityDbContext _db;

    public UploadController(CatchsmartIdentityDbContext db)
    {
        _db = db;
    }

    public class ImageData
    {
        public string Data { get; set; }
    }

    [System.Web.Http.HttpPost]
    [Consumes("multipart/form-data")]
    public IActionResult Index()
    {
        const string key = "Data";
        
        if (Request.Form.ContainsKey(key))
        {
            var base64Data = Request.Form[key].Aggregate((str, val) => str + val) ?? "";
            var AvatarId = "Avatar_" + Guid.NewGuid();

            var avatar = new Avatar()
            {
                AvatarBlobBytes = Encoding.ASCII.GetBytes(base64Data),
                Id = AvatarId
            };
                
            _db.Avatars.Add(avatar);
            _db.SaveChanges();
            
            var responseData = new { AvatarId };
            return new OkObjectResult(responseData);
        }

        return new BadRequestObjectResult($"Invalid post data! Data should be under {{{key}: [yourdata]}}");
    }
}