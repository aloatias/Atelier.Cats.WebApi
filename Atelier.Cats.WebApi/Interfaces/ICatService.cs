using System.Threading.Tasks;

namespace Atelier.Cats.WebApi.Interfaces
{
    public interface ICatService
    {
        Task ImportCatsCatalogAsync();
    }
}
