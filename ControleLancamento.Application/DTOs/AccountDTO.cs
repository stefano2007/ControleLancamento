using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleLancamento.Application.DTOs
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public AccountTypeDTO AccountType { get; set; }
        public string Name { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
