using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace BlazorDemoTesting.Client.Pages
{
    //public partial class Counter
    //{
    //    private int currentCount = 0;

    //    private void IncrementCount()
    //    {
    //        currentCount++;
    //    }
    //}

    public class CounterBase : ComponentBase
    {
        public int currentCount = 0;

        public void IncrementCount()
        {
            currentCount++;
        }
    }
}