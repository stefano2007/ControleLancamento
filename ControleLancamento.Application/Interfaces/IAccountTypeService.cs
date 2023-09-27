using ControleLancamento.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLancamento.Application.Interfaces
{
    public interface IAccountTypeService
    {
        Task<IEnumerable<AccountTypeDTO>> GetAccountTypesAsync();
        Task<AccountTypeDTO> GetByIdAsync(int? id);
        Task<AccountTypeDTO> CreateAsync(AccountTypeCreateDTO categoryDto);
        Task<AccountTypeDTO> UpdateAsync(AccountTypeUpdateDTO categoryDto);
        Task RemoveAsync(int? id);
    }
}
