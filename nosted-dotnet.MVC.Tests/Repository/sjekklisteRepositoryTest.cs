using Microsoft.EntityFrameworkCore;
using nosted_dotnet.MVC.Data;
using nosted_dotnet.MVC.Entities;

namespace nosted_dotnet.MVC.Tests.Repository
{
    public class SjekklisteRepositoryUnitTest
    {
        public class TestDataContext : DataContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseInMemoryDatabase("TestDatabase");
            }
        }

        private TestDataContext _context;

        public SjekklisteRepositoryUnitTest()
        {

            //_context = new TestDataContext
            {
                // Kan ikke være null?
                /*Users = null,
                Produkt = null,
                Kunde = null,
                Adresse = null,
                Ordre = null,
                ServiceSkjema = null,
                Sjekkliste = null*/
            };
            _context.Sjekkliste.Add(new Sjekkliste { Id = 1, OrdreId = 1 });
            _context.SaveChanges();
        }

        [Fact]
        public void Get_ReturnsCorrectSjekkliste()
        {
            // Arrange
            var repository = new SjekklisteRepository(_context);

            // Act
            var sjekkliste = repository.Get(1);

            // Assert
            Assert.NotNull(sjekkliste);
            Assert.Equal(1, sjekkliste.Id);
        }

        [Fact]
        public void GetByOrderId_ReturnsCorrectSjekkliste()
        {
            // Arrange
            var repository = new SjekklisteRepository(_context);

            // Act
            var sjekkliste = repository.GetByOrderId(1);

            // Assert
            Assert.NotNull(sjekkliste);
            Assert.Equal(1, sjekkliste.OrdreId);
        }

        [Fact]
        public void Create_AddsNewSjekkliste()
        {
            // Arrange
            var repository = new SjekklisteRepository(_context);
            var newSjekkliste = new Sjekkliste { Id = 2, OrdreId = 2 };

            // Act
            repository.Create(newSjekkliste);

            // Assert
            Assert.Equal(2, _context.Sjekkliste.Count());
            Assert.Equal(2, _context.Sjekkliste.Last().Id);
        }
    }
}