using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Automatinis_Testavimas.Tools
{
    public class My_ss
    {
        public static void Make_screen_shot(IWebDriver driver)
        {
            //Console.WriteLine(Assembly.GetExecutingAssembly().Location);
            Screenshot my_browser_screen_shot = driver.TakeScreenshot();
            string screen_shot_directory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));
            string screen_shot_folder = Path.Combine(screen_shot_directory, "screenshot");
            Directory.CreateDirectory(screen_shot_folder);
            string screen_shot_name = $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:HH - mm}.png";
            string screen_shot_Path = Path.Combine(screen_shot_folder, screen_shot_name);
            my_browser_screen_shot.SaveAsFile(screen_shot_Path, ScreenshotImageFormat.Png);

        }
    }
}
