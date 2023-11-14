using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTransacoesImobiliarias.Controllers;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;
using ProjetoTransacoesImobiliarias.Interfaces;
using ProjetoTransacoesImobiliarias.Services;


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

        public Client(string name, string address, string phoneNumber, User addedBy, int addedById)
        {
            Name = name;
            Address = address;
            AddedBy = addedBy;
            PhoneNumber = phoneNumber;
            AddedById = addedById;
        }

        [JsonConstructor]
        public Client(string name, string address, string phoneNumber, int addedById)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            AddedById = addedById;
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