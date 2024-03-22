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

    // ViewModel ���壬��Ϊҳ�����ڲ���һ��Ƕ����
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

        // OnPropertyChanged �������������Ը���ʱ֪ͨ�󶨵���ͼ
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // ���س�ʼ���ݻ�������ݵķ���
        public async Task LoadMoreItems()
        {
            if (IsLoading) return;

            IsLoading = true;

            try
            {
                // ʾ��: �������ģ����ʱ
                await Task.Delay(1000);

                // ʵ��Ӧ���У�����Ӧ������������ݵ����ϵ��߼�
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