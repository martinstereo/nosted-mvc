

namespace nosted_dotnet.MVC.Data.ServiceSkjema

{
    public interface IServiceSkjemaRepository
    {
        void Upsert(Entities.ServiceSkjema serviceSkjema);
        Entities.ServiceSkjema Get(int id);
        List<Entities.ServiceSkjema> GetAll();
        Entities.ServiceSkjema GetByOrderId(int id);
        
        // henter en liste med serviceskjema
        List<Entities.ServiceSkjema> GetAllServiceSchemas();
    }
}