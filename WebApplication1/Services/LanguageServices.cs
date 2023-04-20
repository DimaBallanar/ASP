using System.Text.Json;
using System.Text;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class LanguageServices
    {        
        public async Task<List<Language>> GetAll()
        {
            return await new LanguageRepositories().GetAll();
        }

        public async Task<Language> GetById(string id)
        {
            return await new LanguageRepositories().GetById(id);
        }

        public async Task Create( Language lg)
        {
            var list = await new LanguageRepositories().GetAll();
            list.FirstOrDefault(lg=> lg.Id == lg.Id);
            if()
        }

    }
}
