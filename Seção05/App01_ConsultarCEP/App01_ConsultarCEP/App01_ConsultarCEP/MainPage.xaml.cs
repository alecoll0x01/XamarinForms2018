using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            //TODO- Validaçoes
            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {2} de {3} {0}, {1} ", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else {
                        DisplayAlert("Erro", "O Endereço n foi encontrado para o cep informado: " + cep, "OK" );
                    }
                   
                }
                catch(Exception e) {
                    DisplayAlert("Erro Critico", e.Message, "OK");

                }
               
            }
           
        }

        private bool isValidCEP(string cep)
        {
            bool valido = true;
            if (cep.Length != 8)
            {
                //ERRO
                DisplayAlert("ERRO", "CEP invalido! O CEP deve ter conter 8 caracteres", "OK");
                valido = false;
            }
            int novoCEP = 0;
            if (!int.TryParse(cep, out novoCEP))
            {
                //ERRO
                DisplayAlert("ERRO", "CEP invalido! O CEP deve ser composto apenas por numeros", "OK");
                valido = false;
            }
            return valido;
        }

    }

}
