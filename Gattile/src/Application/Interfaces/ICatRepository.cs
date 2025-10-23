using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICatRepository
    {
        void addCat(Cat cat);
        IEnumerable<Cat> getAllCats();

    }
}
