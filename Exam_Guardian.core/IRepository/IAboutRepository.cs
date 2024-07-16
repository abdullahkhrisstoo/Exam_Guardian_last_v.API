using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IRepository
{
    public interface IAboutRepository
    {
        Task CreateAbout(AboutDTO aboutDto);
        Task DeleteAbout(decimal id);
        Task<About> getAboutById(decimal id);
        Task<List<About>> GetAllAbout();
        Task UpdateAbout(decimal id, AboutDTO aboutDto);



    }
}
