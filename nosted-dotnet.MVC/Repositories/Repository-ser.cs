using Microsoft.EntityFrameworkCore;
using nosted_dotnet.MVC.Entities;

namespace nosted_dotnet.MVC.Repositories
{
    public interface IServiceSchemaRepository
    {
        Task<ServiceSchema> AddServiceSchema(ServiceSchema ServiceSchema);

        Task UpdateServiceSchema(ServiceSchema ServiceSchema);

        Task DeleteServiceSchema(int ServiceSchemaId);

        Task<ServiceSchema?> GetServiceSchemaById(int id);

        Task<List<ServiceSchema>> GetAllServiceSchema(); //er det riktig?
    };

    public class ServiceSchemaRepository : IServiceSchemaRepository
    {
        private readonly NostedDbContext _context;

        public ServiceSchemaRepository(NostedDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceSchema> AddServiceSchema(ServiceSchema ServiceSchema)
        {
            await _context.ServiceSchemas.AddAsync(ServiceSchema);

            await _context.SaveChangesAsync();
            
            return ServiceSchema;
        }

        public async Task UpdateServiceSchema(ServiceSchema ServiceSchema)
        {
            var entity = _context.ServiceSchemas.Single(w => w.Id == ServiceSchema.Id);

            entity.RepBeskrivelse = ServiceSchema.RepBeskrivelse;
            entity.MedgåtteDeler = ServiceSchema.MedgåtteDeler;
            entity.FerdigDato = ServiceSchema.FerdigDato;
            entity.UtskiftetDelerRetur = ServiceSchema.UtskiftetDelerRetur;
            entity.ForsendelsesMåte = ServiceSchema.ForsendelsesMåte;
            entity.SignaturRep = ServiceSchema.SignaturRep;
            entity.UserId= ServiceSchema.UserId;
            entity.OrderId= ServiceSchema.OrderId;
            

            await _context.SaveChangesAsync();
        }

        public async Task DeleteServiceSchema(int ServiceSchemaId)
        {
            await _context.ServiceSchemas.Where(w => w.Id == ServiceSchemaId).ExecuteDeleteAsync();

            await _context.SaveChangesAsync();
        }

        public async Task<ServiceSchema?> GetServiceSchemaById(int id)
        {
            return await _context.ServiceSchemas.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<List<ServiceSchema>> GetAllServiceSchema()
        {
            return await _context.ServiceSchemas.ToListAsync();
        }
    }
}