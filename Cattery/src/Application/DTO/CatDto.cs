using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public record CatDto (
        string Name,
        string Breed,
        bool Male,
        string? Description,
        DateTime? ExitDate,
        DateTime? BirthDate,
        string CodeId
        );
}
