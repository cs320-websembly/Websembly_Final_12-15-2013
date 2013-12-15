/*Alex Poon, Emma Haley, Monica Starr Feldman, and Emily Tohir
     Wellesley College 
     Computer Science CS 320
     Advisor: Orit Shaer 
     December 13, 2013
 */

//Your changes have been saved
using System;
using System.Collections.Generic;
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

namespace SurfaceApplication1
{
    /// <summary>
    /// Interaction logic for TagVisualization2.xaml
    /// </summary>
    public partial class TagVisualization2 : TagVisualization
    {
        public TagVisualization2()
        {
            InitializeComponent();
        }

        private void TagVisualization2_Loaded(object sender, RoutedEventArgs e)
        {
            MessageText1.Inlines.Add("You changes have been saved");
        }
    }
}
