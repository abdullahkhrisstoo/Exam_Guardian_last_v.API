using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IRepository;
using Exam_Guardian.core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Service
{
    public class AboutService : IAboutService
    {
        private readonly IAboutRepository _aboutRepository;

        public AboutService(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public  Task CreateAbout(AboutDTO about)
        {
          return _aboutRepository.CreateAbout(about);
        }

        public Task DeleteAbout(decimal id)
        {
            return _aboutRepository.DeleteAbout(id);
        }

        public Task<About> getAboutById(decimal id)
        {
            return _aboutRepository.getAboutById(id);
        }

        public Task<List<About>> GetAllAbout()
        {
            return _aboutRepository.GetAllAbout();
        }

        public Task UpdateAbout(decimal id, AboutDTO aboutDto)
        {
            return _aboutRepository.UpdateAbout(id,aboutDto);
        }
    }
}
