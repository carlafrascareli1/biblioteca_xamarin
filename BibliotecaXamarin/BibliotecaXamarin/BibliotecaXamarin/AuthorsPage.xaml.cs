﻿using BibliotecaXamarin.Model;
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
	public partial class AuthorsPage : ContentPage
	{
        public AuthorsPage()
        {
            InitializeComponent();
        }

        // Executado toda vez que a tela for exibida.
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Pega o view model pelo cast do BindingContext e executa o GetCommand.
            // Isso deve popular a lista de autores inicialmente.
            (BindingContext as AuthorsViewModel).GetCommand.Execute(null);
        }

        // Executado quando a requisição de consulta dos autores falha.
        void Handle_RequestFailed(object sender, ErrorResponse e)
        {
            // Mostra alerta.
            DisplayAlert("Erro", e.Message, "ok");
        }

        async void NewAuthor_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(
                new NewAuthorPage()
            );
        }
    }
}