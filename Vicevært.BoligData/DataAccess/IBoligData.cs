using Refit;
using Vicevært.BoligData.Models;

namespace Vicevært.BoligData.DataAccess
{
    public interface IBoligData
    {

        [Get("/Ejendom")] Task<List<EjendomModel>> GetEjendom();


        //Lejemål

        [Get("/Ejendom/{id}/Lejemaal")] Task<List<LejemaalModel>?> ListLejemaalOnEjendom([AliasAs("id")] Guid ejendomId);
    }
}
