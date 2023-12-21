using System.Text.Json.Serialization;

namespace ProjetoTransacoesImobiliarias.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int AddedById {get; set;}
        public User AddedBy { get; set; }

        public string NIF { get; set; }

        public static List<Client> ClientList = new List<Client>();

        public Client(string name, string address, string phoneNumber, User addedBy, int addedById)
        {
            Name = name;
            Address = address;
            AddedBy = addedBy;
            PhoneNumber = phoneNumber;
            AddedById = addedById;
            ClientList.Add(this);
        }

        [JsonConstructor]
        public Client(string name, string address, string phoneNumber, int addedById)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            AddedById = addedById;
            ClientList.Add(this);
        }
        /// <summary>
        /// Contructor for UserForms
        /// </summary>
        public Client(string name, string address, string dataNasc, string nif)
        {
            Name = name;
            Address = address;
            PhoneNumber = dataNasc;
            NIF = nif;
        }

        public void SetAddedBy(User user)
        {
            AddedBy = user;
        }

        public string AddedByName() {
            return AddedBy != null ? AddedBy.Name : "Desconhecido";
        }

        public string AddedByUsername() {
            return AddedBy != null ? AddedBy.Username : "Desconhecido";
        }

        protected bool RemoveClient()
        {
            //remove cliente na instancia atual
            //    ClientList.Remove(this);
            return true;
        }

    }
}