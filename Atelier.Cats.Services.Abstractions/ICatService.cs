using System.Threading.Tasks;

namespace Atelier.Cats.Services.Abstractions
{
    public interface ICatService
    {
        Task ImportCatsCatalogAsync();
    }
}
