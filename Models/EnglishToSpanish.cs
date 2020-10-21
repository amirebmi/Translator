using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Translator.Models
{
    public class EnglishToSpanish
    {
        public int Id { get; set; }

        public String EngWord { get; set; }

        // Definition in Spanish
        public String Definition { get; set; }
    }
}
