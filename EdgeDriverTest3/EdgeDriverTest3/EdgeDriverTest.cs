using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExample
{
    [TestClass]
    public class EdgeDriverTest
    {
        private const string edgeDriverDirectory = ".";
        private const string bradUrl = "http://127.0.0.1:5500/ToDo10/index.html#";
        private EdgeDriver browser;

        // This is run before each test.
        [TestInitialize]
        public void EdgeDriverInitialize()
        {
            browser = new EdgeDriver(edgeDriverDirectory);
            // We want to go to the same URL for all tests.
            browser.Url = bradUrl;
        }

        [TestMethod]
        public void CheckPageTitle()
        {
            // Check the page title.
            Assert.AreEqual("Todo List App", browser.Title);


        }

        [TestMethod]
        public void CheckItemAdded()
        {

            var userinput = browser.FindElementByCssSelector(".input_text");

            userinput.SendKeys("swim");

            userinput.SendKeys(Keys.Enter);

            Assert.AreEqual("swim", browser.FindElementByCssSelector(".todo-text").Text);

        }
        [TestMethod]
        public void CheckNumberLeft()
        {
            var input1 = browser.FindElementByCssSelector(".input_text");
            input1.SendKeys("football");
            input1.SendKeys(Keys.Enter);

            Assert.AreEqual("1", browser.FindElementByCssSelector("#uncompleted").Text);
            var check = browser.FindElementByCssSelector(".toggle");
            check.Click();
            Assert.AreEqual("0", browser.FindElementByCssSelector("#uncompleted").Text);
        }
       
        
        [TestMethod]
        public void CheckallList()
        {
            var input = browser.FindElementByCssSelector(".input_text");
            input.SendKeys("run");
            input.SendKeys(Keys.Enter);
            input.SendKeys("shopping");
            input.SendKeys(Keys.Enter);
            input.SendKeys("eat");
            input.SendKeys(Keys.Enter);
            Assert.AreEqual("3", browser.FindElementByCssSelector("#uncompleted").Text);
            var check = browser.FindElementByCssSelector(".toggle");
            check.Click();
            Assert.AreEqual("2", browser.FindElementByCssSelector("#uncompleted").Text);

           

        }
        
       
    }
} 