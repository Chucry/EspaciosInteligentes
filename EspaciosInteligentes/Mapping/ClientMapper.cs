using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EspaciosInteligentes.Models;
using EspaciosInteligentes.Persistence;
using EspaciosInteligentes.ViewModels;

namespace EspaciosInteligentes.Mapping
{
    public class ClientMapper
    {
        public EIContext db;

        public ClientMapper()
        {
            db = new EIContext();
        }
        public Client ClientViewModelToClient(ClientViewModel clientVM)
        {
            var client = new Client()
            {
                Id = clientVM.Id,
                Name = clientVM.Name,
                LastName = clientVM.LastName,
                Email = clientVM.Email,
                Password = clientVM.Password,
                BirthDate = clientVM.BirthDate,
                ContactNumber = clientVM.ContactNumber,
                CityId = clientVM.City.Id,
                City = clientVM.City
            };

            return client;
        }

        public ClientViewModel ClientToClientViewModel(Client client)
        {
            var clientVM = new ClientViewModel()
            {
                Id = client.Id,
                Name = client.Name,
                LastName = client.LastName,
                Email = client.Email,
                Password = client.Password,
                BirthDate = client.BirthDate,
                ContactNumber = client.ContactNumber,
                City = db.Cities.First(c => c.Id == client.CityId),
                CityList = new List<SelectListItem>()
            };

            return clientVM;
        }
    }
}