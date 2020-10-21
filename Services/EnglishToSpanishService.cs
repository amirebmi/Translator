using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Translator.Models;

namespace Translator.Services
{
    public interface IEnglishToSpanishService
    {
        List<EnglishToSpanish> GetDefinitions(String englishToSpanish);
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

        public List<EnglishToSpanish> GetDefinitions(String englishTospanish)
        {
            var definitions = _db.SpanishDefinitions.Where(d => d.EngWord == englishTospanish).ToList();



            return definitions;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
