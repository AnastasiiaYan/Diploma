using Diploma.Models;

namespace Diploma.Services.SystemFields;

public interface ISystemFieldsService
{
    Task<Models.SystemFields> GetSystemFields();
}