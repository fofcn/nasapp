namespace nasapp;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    private async void OnImage1Clicked(object sender, EventArgs e)
    {
        // 点击第一个图片，跳转到第一个列表页面
        await Navigation.PushAsync(new PicturePage());
    }

    private async void OnImage2Clicked(object sender, EventArgs e)
    {
        // 点击第二个图片，跳转到第二个列表页面
        await Navigation.PushAsync(new VideoPage());
    }

    private async void OnImage3Clicked(object sender, EventArgs e)
    {
        // 点击第三个图片，跳转到第三个列表页面
        await Navigation.PushAsync(new DocPage());
    }
}