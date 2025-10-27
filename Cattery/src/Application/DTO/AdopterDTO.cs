using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public record AdopterDTO(
        string Name,
        string PhoneNumber,
        string Email,
        string Address
        );
}
