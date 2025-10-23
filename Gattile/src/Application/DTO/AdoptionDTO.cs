using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public record AdoptionDTO
        (
        CatDto Cat,
        AdopterDTO Adopter,
        DateTime AdoptionDate
        );    
}
