using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorDemoTesting.Client.Pages;
using Bunit;

namespace BlazorDemoTesting.Client.Tests.Pages
{
    [TestFixture]
    public class CounterFixture
    {
        [Test]
        public void Counter_Init_ViewCountZero()
        {
            var ctx = new Bunit.TestContext();

            var counter = ctx.RenderComponent<Counter>();

            counter.MarkupMatches(
                @"
<h1>Counter</h1>
<p role=""status"">Current count: 0</p>
<button class=""btn btn-primary"" >Click me</button>"
            );
        }


        [Test]
        public void Counter_Click_ViewCountOne()
        {
            var ctx = new Bunit.TestContext();

            var counter = ctx.RenderComponent<Counter>();

            var button = counter.Find("button");
            button.Click();

            var change = counter.GetChangesSinceFirstRender();

            Assert.AreEqual(1, change.Count);

            change[0].ShouldBeTextChange("Current count: 1");
        }
    }
}