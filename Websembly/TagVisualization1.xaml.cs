/*Alex Poon, Emma Haley, Monica Starr Feldman, and Emily Tohir
     Wellesley College 
     Computer Science CS 320
     Advisor: Orit Shaer 
     December 13, 2013
 */

//Your photos and videos have been loaded into Websembly"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Input;
using System.IO;

namespace SurfaceApplication1
{
    /// <summary>
    /// Interaction logic for TagVisualization1.xaml
    /// </summary>
    public partial class TagVisualization1 : TagVisualization
    {
        public TagVisualization1()
        {
            InitializeComponent();
        }

        private void TagVisualization1_Loaded(object sender, RoutedEventArgs e)
        {
            MessageText.Inlines.Add("Hi Orit! \n");
            MessageText.Inlines.Add(new Bold(new Run("Your photos and videos have been loaded into Websembly.")));
        }

    }
}
