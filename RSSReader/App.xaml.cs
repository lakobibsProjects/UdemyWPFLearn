﻿using RSSReader.View;
using RSSReader.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RSSReader
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DependencyInjector.Register<IRSSHelper, RSSHelper>();
            MainWindow = DependencyInjector.Retrive<MainWindow>();
        }
    }
}
