using Core.Application.Common.Interfaces;
using Core.Application.Common.Models.DTOs;
using Core.Infrastructure.Common.Localization;
using Microsoft.Extensions.Localization;

namespace Core.Infrastructure.Services
{
    public class BaseLocalizationService : ILocalizationService
    {
        private readonly IStringLocalizer<BaseResource> _localizer;
        public BaseLocalizationService(IStringLocalizer<BaseResource> localizer)
        {
            _localizer = localizer;
        }

        public virtual string Translate(string key)
        {
            return _localizer[key].Value;
        }

        public virtual IList<ResourceDto> GetResources()
        {
            var resources = _localizer.GetAllStrings().Select(x => new ResourceDto
            {
                Name = x.Name,
                Value = x.Value
            }).ToList();

            return resources;
        }
    }
}
