using nosted_dotnet.MVC.Entities;
using System;
using System.Collections.Generic;

namespace nosted_dotnet.MVC.Repositories
{
    public interface IOrdreRepository
    {
        void Upsert(Ordre ordre);
        Ordre Get(int id);
        List<Ordre> GetAll();
        void Delete(int id); // Add this method for deleting an order
    }
}