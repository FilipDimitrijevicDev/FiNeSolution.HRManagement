using Core.Application.Common.Models.DTOs;

namespace Core.Application.Common.Interfaces
{
    public interface ILocalizationService
    {

        string Translate(string key);
        IList<ResourceDto> GetResources();
    }
}
