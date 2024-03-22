namespace nasapp;

public partial class VideoPage : ContentPage
{
	public VideoPage()
	{
		InitializeComponent();
        BindingContext = this;
    }

    public List<string> Items { get; set; } = new List<string> { "Apple", "Banana", "Orange" };
}