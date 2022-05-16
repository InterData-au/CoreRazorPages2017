using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorWebApp1.Pages
{
    public class AboutModel : PageModel
    {
        private readonly IHostingEnvironment _env;
        public string OSDescription;
        public string ProcessArchitecture;

        public string ThisEnvironment { get; set; }
        public string MyApplicationName { get; set; }
        public string TargetFramework { get; set; }

        public AboutModel(IHostingEnvironment env)
        {
            _env = env;
        }

        public void OnGet()
        {
            ThisEnvironment = _env.EnvironmentName;
            MyApplicationName = _env.ApplicationName;

            OSDescription = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            ProcessArchitecture = System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture.ToString();

            var atrib = Assembly.GetExecutingAssembly().CustomAttributes.FirstOrDefault(a => a.AttributeType == typeof(TargetFrameworkAttribute));
            TargetFramework = atrib?.ConstructorArguments[0].Value.ToString();

        }
    }
}