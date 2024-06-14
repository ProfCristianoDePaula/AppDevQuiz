namespace DevQuiz.Pages;

public partial class Pergunta2 : ContentPage
{
    bool respondeu = false;
    bool acertou = false;
    int soma = 0;

    public Pergunta2()
    {
        InitializeComponent();
    }

    protected async override void OnAppearing()
    {
        string resultado;
        base.OnAppearing();
        resultado = await SecureStorage.Default.GetAsync("soma");
        soma = Convert.ToInt32(resultado);
    }

    private async void btnResponder_Clicked(object sender, EventArgs e)
    {
        string resposta = acertou ? "Acertou" : "Errouuuuuuuu";
        soma = acertou ? soma + 1 : soma;
        await DisplayAlert("Resposta", resposta, "Ok");
        await SecureStorage.Default.SetAsync("soma", soma.ToString());
        await Navigation.PushAsync(new Pergunta3());
    }

    private void Verificar(object sender, EventArgs e)
    {
        string valor = "0";

        if (respondeu)
        {
            respondeu = false;
        }
        RadioButton opcao = (RadioButton)sender;
        if (opcao.IsChecked)
        {
            valor = opcao.Value.ToString();
            respondeu = true;

            if (valor == "1")
            {
                acertou = true;
            }
        }
    }
}