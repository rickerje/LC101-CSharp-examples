using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;

namespace Studio3._3.Controllers
{
    public class HelloController : Controller
    {
        [HttpGet]
        public IActionResult Goodbye()
        {
            return Content(GetGoodbyeHtml(), "text/html");
        }

        [HttpPost]
        public IActionResult Goodbye(string name, string language)
        {
            string result = CreateMessage(name, language);
            return Content(result, "text/html" );
        }

        private static string CreateMessage(string name, string language)
        {
            string goodbye;
            switch (language)
            {
                case "English":
                    goodbye = "Goodbye";
                    break;
                case "French":
                    goodbye = "Bonjour";
                    break;
                case "Russian":
                    goodbye = "Do svidaniya";
                    break;
                case "Spanish":
                    goodbye = "Adios";
                    break;
                default:
                    goodbye = "Goodbye";
                    break;
            }
            
            return $"{goodbye}, {name}!"; ;
        }

        private string GetGoodbyeHtml()
        {
            return @"<html><h2>GoodBye</h2>
                        <form method='post'>
                            <input type='text' name='name' />
                            <select name='language' >    
                                <option value='English' > English </option >
                                <option value='Spanish' > Spanish </option >
                                <option value='French' > French </option >
                                <option value='Russian' > Russian </option >
                            </select >
                            <button type='submit' > Submit </button >
                        </form ></html> ";
        }

        [HttpGet]
        public IActionResult SOSTransmission()
        {
            string html = @"<html><form method='post'>
                                <input type='text' name='sosmessage' />
                                <button type='submit'>Submit</button>
                            </form></html>";
            return Content(html, "text/html");
        }

        [HttpPost]
        public IActionResult SOSTransmission(string sosmessage)
        {
            int errorCount = CountTransmissionErrors(sosmessage);
            return Content($"<h2>There were {errorCount} transmission errors</h2>", "text/html");
        }

        private int CountTransmissionErrors(string sosString)
        {
            int errorCount = 0;

            for (int i = 0; i < sosString.Length; i += 3)
            {
                char letter = sosString[i];
                int position = i % 3;
                switch (position)
                {
                    case 0:
                    case 2:
                        if (letter != 'S')
                            errorCount++;
                        break;
                    case 1:
                        if (letter != 'O')
                            errorCount++;
                        break;
                }
            }

            return errorCount;
        }
    }
}