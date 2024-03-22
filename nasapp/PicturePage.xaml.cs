using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace nasapp;

public partial class PicturePage : ContentPage
{
	public PicturePage()
	{
		InitializeComponent();
        BindingContext = new PictureViewModel();
    }

    // ViewModel 定义，作为页面类内部的一个嵌套类
    // PictureViewModel.cs
    public class PictureViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<string> Items { get; } = new ObservableCollection<string>();
        public ICommand LoadMoreItemsCommand { get; }
        private bool isLoading;

        public PictureViewModel()
        {
            LoadMoreItemsCommand = new Command(async () => await LoadMoreItems());
            Task.Run(() => LoadMoreItems());
        }

        public bool IsLoading
        {
            get => isLoading;
            set
            {
                isLoading = value;
                OnPropertyChanged();
            }
        }

        // OnPropertyChanged 方法用于在属性更改时通知绑定的视图
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // 加载初始数据或更多数据的方法
        public async Task LoadMoreItems()
        {
            if (IsLoading) return;

            IsLoading = true;

            try
            {
                // 示例: 加载项的模拟延时
                await Task.Delay(1000);

                // 实际应用中，这里应该是添加新数据到集合的逻辑
                var newItems = new List<string> { "https://copyright.bdstatic.com/vcg/creative/cc9c744cf9f7c864889c563cbdeddce6.jpg@h_1280", "https://copyright.bdstatic.com/vcg/creative/cc9c744cf9f7c864889c563cbdeddce6.jpg@h_1280", "https://copyright.bdstatic.com/vcg/creative/cc9c744cf9f7c864889c563cbdeddce6.jpg@h_1280" };
                foreach (var item in newItems)
                {
                    Items.Add(item);
                }
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}