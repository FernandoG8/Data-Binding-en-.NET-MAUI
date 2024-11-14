namespace AplicacionPractica
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(FormPage), typeof(FormPage));


        }
    }
}
