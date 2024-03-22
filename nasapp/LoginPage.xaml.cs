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
        
        // ����������͵�¼����
        bool loginSuccessful = await LoginToServer(username, password);

        bool isIgnoreLogin = true;
        if (isIgnoreLogin)
        {
            loginSuccessful = true;
        }

        if (loginSuccessful)
        {
            // ��¼�ɹ�����ת����ҳ
            await Navigation.PushAsync(new HomePage());
        }
        else
        {
            // ��¼ʧ�ܣ���ʾ������Ϣ
            await DisplayAlert("��¼ʧ��", "�û������������", "ȷ��");
        }
    }

    private async Task<bool> LoginToServer(string username, string password)
    {
        // ����HTTP POST���󵽷�������֤�û���������
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
                // ������������سɹ�״̬�룬���¼�ɹ�
                return true;
            }
            else
            {
                // ��¼ʧ��
                return false;
            }
        } 
        catch(Exception ex)
        {
            return false;
        }
        

       
    }
}