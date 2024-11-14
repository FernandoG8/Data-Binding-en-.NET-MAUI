
using AplicacionPractica;

using System.Collections.ObjectModel;
using System.Text.Json;


namespace AplicacionPractica
{

    public partial class MainPage : ContentPage
    {
        private readonly HttpClient _clientHttp = new HttpClient();
        private ObservableCollection<PersonaModel> personas;

        public ObservableCollection<PersonaModel> Personas
        {
            get => personas;
            set
            {
                personas = value;
                OnPropertyChanged();
            }
        }
        public MainPage()
        {
            InitializeComponent();
            GetData();
            BindingContext = this;
        }

        
        public async void GetData()
        {
            var response = await _clientHttp.GetStringAsync("https://fi.jcaguilar.dev/v1/escuela/persona");
            var personas = JsonSerializer.Deserialize<ObservableCollection<PersonaModel>>(response);
            Personas = personas;
            

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FormPage());
        }
    }
}
