using BibliotecaXamarin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BibliotecaXamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewAuthorPage : ContentPage
	{
        public NewAuthorPage()
        {
            InitializeComponent();
        }

        // Executado quando a requisição de consulta dos autores falha.
        void Handle_RequestFailed(object sender, ErrorResponse e)
        {
            // Mostra alerta.
            DisplayAlert("Erro", e.Message, "ok");
        }

        async void Handle_AuthorAdded(object sender, Author author)
        {
            await Navigation.PushAsync(
                new AuthorsPage()
            );
        }
    }
}