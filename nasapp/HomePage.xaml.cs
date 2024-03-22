namespace nasapp;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    private async void OnImage1Clicked(object sender, EventArgs e)
    {
        // �����һ��ͼƬ����ת����һ���б�ҳ��
        await Navigation.PushAsync(new PicturePage());
    }

    private async void OnImage2Clicked(object sender, EventArgs e)
    {
        // ����ڶ���ͼƬ����ת���ڶ����б�ҳ��
        await Navigation.PushAsync(new VideoPage());
    }

    private async void OnImage3Clicked(object sender, EventArgs e)
    {
        // ���������ͼƬ����ת���������б�ҳ��
        await Navigation.PushAsync(new DocPage());
    }
}