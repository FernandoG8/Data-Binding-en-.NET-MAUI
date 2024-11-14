using System.Text;
using System.Text.Json;

namespace AplicacionPractica;

public partial class FormPage : ContentPage
{
    private readonly HttpClient _clientHttp = new HttpClient();
    public FormPage()
	{
		InitializeComponent();
	}
    private async void OnGuardarPersonaClicked(object sender, EventArgs e)
    {
        // Crear un objeto con los datos del formulario
        var nuevaPersona = new PersonaModel
        {
            nombre = nombre.Text,
            apellido = apellido.Text,
            sexo = GetSelectedSexo(),
            fh_nac = fechaNacimiento.Date.ToString("yyyy-MM-dd"),
            id_rol = int.TryParse(idRol.Text, out int idRolValue) ? idRolValue : 0 
        };

        // Serializar a JSON
        var json = JsonSerializer.Serialize(nuevaPersona);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Enviar a la API
        var response = await _clientHttp.PostAsync("https://fi.jcaguilar.dev/v1/escuela/persona", content);

        if (response.IsSuccessStatusCode)
        {
            await DisplayAlert("Éxito", "La persona fue guardada exitosamente.", "OK");
            await Navigation.PushAsync(new MainPage());
        }
        else
        {
            await DisplayAlert("Error", "Hubo un problema al guardar la persona.", "OK");
        }
    }

    private string GetSelectedSexo()
    {
        if (sexoMasculino.IsChecked)
            return "M";
        else if (sexoFemenino.IsChecked)
            return "F";
        else
            return null;
    }
}
