using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Translator.Models;

namespace Translator.Services
{
    public interface IEnglishToSpanishService
    {
        List<EnglishToSpanish> GetDefinitions(EnglishToSpanish englishToSpanish);
        void AddWord(EnglishToSpanish englishToSpanish);

        void SaveChanges();
    }

    public class EnlgishToSpanishService : IEnglishToSpanishService
    {

        private readonly AppDbContext _db;

        public EnlgishToSpanishService(AppDbContext db)
        {
            _db = db;
        }

        public void AddWord(EnglishToSpanish englishToSpanish)
        {
            _db.Add(englishToSpanish);
        }

        public List<EnglishToSpanish> GetDefinitions(EnglishToSpanish englishToSpanish)
        {
            var definitions = _db.SpanishDefinitions.Where(d => d.Definition == englishToSpanish.EngWord).ToList();

            return definitions;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
