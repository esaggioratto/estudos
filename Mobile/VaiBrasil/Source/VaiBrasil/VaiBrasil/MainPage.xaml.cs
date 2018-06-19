using System;
using Xamarin.Forms;
using VaiBrasil.service;
using VaiBrasil.service.model;

namespace VaiBrasil
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private void btnConsultar_Clicked(object sender, EventArgs e)
        {
            try
            {
                ViaCepModel endResult = ViaCepService.GetAdress(CepValido(txtCep));
                if (endResult != null)
                {
                    txtResultado.Text = string.Format("{0} {1},{2}-{3},{4}-{5}", endResult.Logradouro, endResult.Complemento, endResult.Bairro, endResult.Localidade, endResult.Cep, endResult.Uf);
                }
                else
                {
                    throw new Exception(string.Format("Cep {0} não localizado.", txtCep.Text));
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "ok");
            }
        }

        private string CepValido(Entry _txtCep)
        {

            if (string.IsNullOrEmpty(_txtCep.Text)) { throw new Exception("Informe um Cep."); }

            Int64 cepNovo = 0;
            if (!Int64.TryParse(_txtCep.Text.Trim(), out cepNovo)) { throw new Exception("Cep inválido."); }

            if (_txtCep.Text.Length != 8) { throw new Exception("Cep inválido. Deve conter 8 números. Ex: 00000000."); }

            return _txtCep.Text;
        }
    }
}
