namespace nasapp;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;
        
        // 向服务器发送登录请求
        bool loginSuccessful = await LoginToServer(username, password);

        bool isIgnoreLogin = true;
        if (isIgnoreLogin)
        {
            loginSuccessful = true;
        }

        if (loginSuccessful)
        {
            // 登录成功，跳转到主页
            await Navigation.PushAsync(new HomePage());
        }
        else
        {
            // 登录失败，显示错误消息
            await DisplayAlert("登录失败", "用户名或密码错误", "确定");
        }
    }

    private async Task<bool> LoginToServer(string username, string password)
    {
        // 发送HTTP POST请求到服务器验证用户名和密码
        HttpClient client = new HttpClient();
        var postData = new List<KeyValuePair<string, string>>();
        postData.Add(new KeyValuePair<string, string>("username", username));
        postData.Add(new KeyValuePair<string, string>("password", password));
        HttpContent content = new FormUrlEncodedContent(postData);

        try 
        {
            HttpResponseMessage response = await client.PostAsync("http://your-server-url/login", content);
            if (response.IsSuccessStatusCode)
            {
                // 如果服务器返回成功状态码，则登录成功
                return true;
            }
            else
            {
                // 登录失败
                return false;
            }
        } 
        catch(Exception ex)
        {
            return false;
        }
        

       
    }
}