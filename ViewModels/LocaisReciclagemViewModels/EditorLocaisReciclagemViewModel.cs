using Flunt.Notifications;
using Flunt.Validations;

namespace ProjetoLocaisDeReciclagem.ViewModels.LocaisReciclagemViewModels
{
    public class EditorLocaisReciclagemViewModel : Notifiable, IValidatable
    {
        public int LocalReciclagemId { get; set; }
        public string Identificacao { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string NumeroEndereco { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public float Capacidade { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .HasMaxLen(Identificacao, 100, "Identificacao", "A identificação deve conter até 100 caracteres")
                    .HasMaxLen(CEP, 10, "CEP", "O CEP deve conter até 10 caracteres")
                    .HasMaxLen(Logradouro, 100, "Logradouro", "O logradouro deve conter até 100 caracteres")
                    .HasMaxLen(NumeroEndereco, 10, "NumeroEndereco", "O número do endereço deve conter até 10 caracteres")
                    .HasMaxLen(Bairro, 50, "Bairro", "O bairro deve conter até 50 caracteres")
                    .HasMaxLen(Cidade, 50, "Cidade", "O cidade deve conter até 50 caracteres")
                    .HasMaxLen(Estado, 2, "Estado", "O estado deve conter 2 caracteres")
                    .IsGreaterThan(Capacidade, 0, "Capacidade", "A capacidade deve ser maior que zero")
            );
        }
    }
}