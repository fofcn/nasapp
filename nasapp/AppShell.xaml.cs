
namespace nasapp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            _ = DecideNavigationAsync();
        }

        private async Task DecideNavigationAsync()
        {
            if (UserIsLoggedIn())
            {
                // 如果用户已登录，导航到 HomePage
                await GoToAsync("//HomePage");
            }
            else
            {
                // 如果用户未登录，导航到 LoginPage
                await GoToAsync("//LoginPage");
            }
        }

        private bool UserIsLoggedIn()
        {
            // 添加您检查用户登录状态的逻辑
            return false; // 假定用户目前没有登录
        }
    }
}
