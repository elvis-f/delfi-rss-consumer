namespace Catchsmart.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class RSSController : Controller
    {
        private readonly UserManager<CatchsmartUser> _userManager;

        public RSSController(UserManager<CatchsmartUser> userManager)
        {
            _userManager = userManager;
        }
        
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            
            if (currentUser == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var category = currentUser.Category;
            var recordCount = currentUser.RecordCount;

            var url = $"https://www.delfi.lv/rss/?channel={category}";

            var feed = GetRSSFeed(url);

            var delfiArticleList = feed.Items.Select(item =>
                    new Article
                    {
                        Title = HttpUtility.HtmlDecode(item.Title.Text),
                        Summary = HttpUtility.HtmlDecode(item.Summary.Text),
                        ImageLink = item.Links[0].Uri.ToString(),
                        Link = item.Id
                    })
                .ToList();

            var viewModel = new RSSViewModel()
            {
                ArticleList = delfiArticleList,
                ArticleCount = Math.Min(recordCount, delfiArticleList.Count),
                Category = category,
            };

            return View(viewModel);
        }
        
        private SyndicationFeed GetRSSFeed(string url)
        {
            var reader = XmlReader.Create(url);
            var feed = SyndicationFeed.Load(reader);
            reader.Close();

            return feed;
        }
    }
}