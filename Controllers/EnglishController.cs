using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Translator.Models;
using Translator.Services;

namespace Translator.Controllers
{
    public class EnglishController : Controller
    {

        private readonly IEnglishToSpanishService _englishToSpanishService;

        public EnglishController(IEnglishToSpanishService englishToSpanishService)
        {
            _englishToSpanishService = englishToSpanishService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(IFormFile file)
        {
            string english;
            string spanish;

            // read all the lines from file
            using var reader = new StreamReader(file.OpenReadStream());

            List<string> lines = new List<string>();

            string line;

            while((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("#")) {
                    continue;
                }
                else
                {
                    string[] words = line.Split(new char[] { '\t' }); // split each line that hat a tab into string array

                    english = words[0];
                    spanish = words[1];

                    var newWord = new EnglishToSpanish
                    {
                        EngWord = english,
                        Definition = spanish
                    };

                    _englishToSpanishService.AddWord(newWord);
                    _englishToSpanishService.SaveChanges();
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Definition()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Definition(String englishTospanish)
        {
            return View(_englishToSpanishService.GetDefinitions(englishTospanish));
        }




        public IActionResult Index()
        {
            return View();
        }
    }
}
