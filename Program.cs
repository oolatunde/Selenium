using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Selenium
{
  class Program
  {
    static void Main(string[] args)
    {
      IWebDriver driver = new ChromeDriver();
      driver.Navigate().GoToUrl("http://thinkingbig.net/about/");

      //Scrapes the executives from the webpage
      IList<IWebElement>executives = new List<IWebElement>();
      executives = driver.FindElements(By.CssSelector("div.executive h2"));
      foreach (var executive in executives)
      {
        Console.WriteLine(executive.Text);
      }

      //Scrapes all the employees from the webpage
      IList<IWebElement>emply = new List<IWebElement>();
      emply = driver.FindElements(By.CssSelector(".content .name"));
      try
      {
        Console.WriteLine();
        var total = emply.Count;
        Console.WriteLine("Total employees: " + total);
        for(int i = 0; i < total; i++)
        {
          Console.WriteLine(emply[i].GetAttribute("innerHTML"));
        }
      }
      catch(IOException e)
      {
        Console.WriteLine(e + "Nothing to display");
      }
      
    }
  }
}
