using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Flurl;
using Flurl.Http;
using Xamarin.Forms;

namespace BibliotecaXamarin.Model
{
    class NewAuthorViewModel : 
        // Essa interface indica que instâncias dessa classe disparam evento
        // avisando quando alguma propriedade muda de valor. Isso é usado pelos
        // bindings, para atualizar valores diversos
        INotifyPropertyChanged
    {
        // Evento de propriedade alterada, deve ser disparado toda vez que uma
        // propriedade muda de valor. Definido em INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler<Author> AuthorAdded;

        // Evento disparado quando requisição falha.
        public event EventHandler<ErrorResponse> RequestFailed;

        public Author author = new Author();

        public ICommand PostCommand { get; private set; }

        public NewAuthorViewModel()
        {
            // Função para ser executada quando o GetCommand for executado.
            async void execute(string value)
            {
                try
                {
                    author.Name = value;
                    await Constants.BaseServiceUrl.AppendPathSegment(typeof(Author).Name).PostJsonAsync(author);

                    AuthorAdded?.Invoke(this, author);

                }
                // Se webservice retornar erro, lança uma FlurlHttpException
                catch (FlurlHttpException ex)
                {
                    // Nesse caso, pega o corpo da resposta de erro e
                    // desserializa como um DTO ErrorResponse
                    var error = await ex.GetResponseJsonAsync<ErrorResponse>();

                    // Invoca evento de requisição zoada.
                    RequestFailed?.Invoke(this, error);
                }
            }

            // Atribui valor ao comando.
            PostCommand = new Command<string>(execute);
        }
    }
}
