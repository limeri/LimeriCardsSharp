using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System;

namespace LimeriCardsSharp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }
    }
}