namespace Gorusel_odevi2;

public partial class Kaydol : ContentPage
{
    private readonly FirebaseService _firebaseService;
    public Kaydol()
	{
        InitializeComponent();
        _firebaseService = new FirebaseService();

    }
    private async void OnLabelTapped(object sender, EventArgs e)
    {
        // Farkl� bir sayfaya y�nlendirme
        await Navigation.PushAsync(new Giris());
    }
    private async void OnRegisterClicked(object sender, EventArgs e)
    {

        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Hata", "E-posta ve �ifre bo� b�rak�lamaz.", "Tamam");
            return;
        }

        string result = await _firebaseService.RegisterUserAsync(email, password);
        await DisplayAlert("Sonu�", result, "Tamam");
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Hata", "E-posta ve �ifre bo� b�rak�lamaz.", "Tamam");
            return;
        }

        string result = await _firebaseService.LoginUserAsync(email, password);
        await DisplayAlert("Sonu�", result, "Tamam");
    }
}