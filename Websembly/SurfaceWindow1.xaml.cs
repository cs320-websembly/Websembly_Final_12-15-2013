/*Alex Poon, Emma Haley, Monica Starr Feldman, and Emily Tohir
     Wellesley College 
     Computer Science CS 320
     Advisor: Orit Shaer 
     December 13, 2013
 */

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
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Collections; 
using System.ComponentModel;
using System.Data;

public class globalVariables{
    public static String originalHTMLPortfolioLayout =  "\n<html>\n\t<head>\n\t\t<style>\n\t\t</style>\n\t\t<title>My Website</title>\n\t</head>\n\t<body>\n\t\t<h1>Type Title Here</h1>\n\t\t<div id='portfolio_examples'>\n\t\t\t<div class='row'>\n\t\t\t\tRow 1, Left Element \n\t\t\t\tRow 1, Center Element \n\t\t\t\tRow 1, Right Element\n\t\t\t</div>\n\t\t\t<div class='row'>\n\t\t\t\tRow 1, Left Caption \n\t\t\t\tRow 1, Center Caption \n\t\t\t\tRow 1, Right Caption\n\t\t\t</div>\n\t\t\t<div class='row'>\n\t\t\t\tRow 2, Left Element \n\t\t\t\tRow 2, Center Element \n\t\t\t\tRow 2, Right Element\n\t\t\t</div>\n\t\t\t<div class='row'>\n\t\t\t\tRow 2, Left Caption \n\t\t\t\tRow 2, Center Caption \n\t\t\t\tRow 2, Right Caption\n\t\t\t</div>\n\t\t</div>\n\t</body>\n</html>";
    public static void changeOriginalHTMLPortfolioLayout(String newHTML){
        originalHTMLPortfolioLayout = newHTML;
    }
    public static String file;
}
namespace SurfaceApplication1
{
    /// <summary>
    /// Interaction logic for SurfaceWindow1.xaml
    /// </summary>
    public partial class SurfaceWindow1 : SurfaceWindow
    {
        SurfaceButton selectedContentButton;
        int buttonInput;
        // Emily coding 11/22
        // Emily added 11/17 --> for library bar
        private ObservableCollection<PhotoData> libraryItems = new ObservableCollection<PhotoData>();
        private ObservableCollection<PhotoData> scatterItems = new ObservableCollection<PhotoData>();
        // Emily added 11/17 --> for library bar

        // creating a library collection of photo data items
        public ObservableCollection<PhotoData> LibraryItems
        {
            get { return libraryItems; }

        }

        // creating a library collection of scatteritems 
        public ObservableCollection<PhotoData> ScatterItems
        {
            get { return scatterItems; }
        }


        /// <summary>
        /// Default constructor.
        /// </summary>
        public SurfaceWindow1()
        {
            InitializeComponent();

            // Add handlers for window availability events
            AddWindowAvailabilityHandlers();
        }

        /// <summary>
        /// Occurs when the window is about to close. 
        /// </summary>
        /// <param name="e"></param>

        //Cpode for library bar
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            DataContext = this;

            LibraryItems.Add(new PhotoData(@"C:\Users\balichmac1\Desktop\WEBSEMBLY_FINAL\Resources\Images\wellesley_sunset.jpg", "Wellesley Sunset", true));
            LibraryItems.Add(new PhotoData(@"C:\Users\balichmac1\Desktop\WEBSEMBLY_FINAL\Resources\Imageswellesley_hooproll.jpg", "Hoop Rolling", true));
            LibraryItems.Add(new PhotoData(@"C:\Users\balichmac1\Desktop\WEBSEMBLY_FINAL\Resources\images\wellesley_sci.jpg", "Science Center", true));
            LibraryItems.Add(new PhotoData(@"C:\Users\balichmac1\Desktop\WEBSEMBLY_FINAL\Resources\Videos\video1.jpg", "Video 1", true));
            LibraryItems.Add(new PhotoData(@"C:\Users\balichmac1\Desktop\WEBSEMBLY_FINAL\Resources\Videos\video2.jpg", "Video 2", true));
            LibraryItems.Add(new PhotoData(@"C:\Users\balichmac1\Desktop\WEBSEMBLY_FINAL\Resources\images\racoon.jpg", "Racoon", true));
            LibraryItems.Add(new PhotoData(@"C:\Users\balichmac1\Desktop\WEBSEMBLY_FINAL\Resources\images\teacup_pig.jpg", "Teacup Pig", true));
            LibraryItems.Add(new PhotoData(@"C:\Users\balichmac1\Desktop\WEBSEMBLY_FINAL\Resources\images\two_pigs.jpg", "Two Pigs", true));
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            // Remove handlers for window availability events
            RemoveWindowAvailabilityHandlers();
        }

        /// <summary>
        /// Adds handlers for window availability events.
        /// </summary>
        private void AddWindowAvailabilityHandlers()
        {
            // Subscribe to surface window availability events
            ApplicationServices.WindowInteractive += OnWindowInteractive;
            ApplicationServices.WindowNoninteractive += OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable += OnWindowUnavailable;
        }

        /// <summary>
        /// Removes handlers for window availability events.
        /// </summary>
        private void RemoveWindowAvailabilityHandlers()
        {
            // Unsubscribe from surface window availability events
            ApplicationServices.WindowInteractive -= OnWindowInteractive;
            ApplicationServices.WindowNoninteractive -= OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable -= OnWindowUnavailable;
        }

        /// Added for the library Bar
        /// Grid Preview Touchdown handler 
        /// Added for Library Bar Implimentation 
        private void Grid_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            //the touch position is stored here
            Point touchPosition;

            //get the position of the current touch
            touchPosition = e.Device.GetPosition(this);

            //create a new thickness to use as margin
            Thickness margin = new Thickness(touchPosition.X, touchPosition.Y, 0, 0);
        }

        /// <summary>
        /// This is called when the user can interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowInteractive(object sender, EventArgs e)
        {
            //Enable audio animations here
        }
        /// <summary>
        /// This is called when the user can see but not interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowNoninteractive(object sender, EventArgs e)
        {
            //Optional: Disable audio here if it is enabled
            //Optional: Enable animations here
        }

        private String getHTML(String locationOfChange, String change)
        {
            String html = globalVariables.originalHTMLPortfolioLayout; //"\n<html>\n\t<head>\n\t\t<style>\n\t\t</style>\n\t\t<title>YOUR TITLE HERE</title>\n\t</head>\n\t<body>\n\t\t<h1>YOUR TITLE HERE</h1>\n\t\t<div id='cover_photo'>\n\t\t\tP_Cover\n\t\t</div>\n\t\t<div id='portfolio_examples'>\n\t\t\t<div class='row'>\n\t\t\t\tP_R1L \n\t\t\t\tP_R1C \n\t\t\t\tP_R1R\n\t\t\t</div>\n\t\t\t<div class='row'>\n\t\t\t\tP_CR1L \n\t\t\t\tP_CR1C \n\t\t\t\tP_CR1R\n\t\t\t</div>\n\t\t\t<div class='row'>\n\t\t\t\tP_R2L \n\t\t\t\tP_R2C \n\t\t\t\tP_R2R\n\t\t\t</div>\n\t\t\t<div class='row'>\n\t\t\t\tP_CR2L \n\t\t\t\tP_CR2C \n\t\t\t\tP_CR2R\n\t\t\t</div>\n\t\t</div>\n\t</body>\n</html>";
            int indexStart = html.IndexOf(locationOfChange);
            html = html.Replace(locationOfChange, change);
            globalVariables.changeOriginalHTMLPortfolioLayout(html);
            int lengthOfChange = change.Length;
            return html;
        }

        /// <summary>
        /// This is called when the application's window is not visible or interactive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowUnavailable(object sender, EventArgs e)
        {
            //Disable audio, animations here

        }

        //Code for display the content after you "drop" it into its place - Row 1, Left Element 
        private void OnDropTargetDrop1(object sender, SurfaceDragDropEventArgs e)
        {
            try
            {
                ImageBrush myBrush = new ImageBrush();
                BitmapImage bitmapImage = new BitmapImage();

                myBrush.ImageSource = new BitmapImage(new Uri(@"C:\Users\balichmac1\Desktop\WEBSEMBLY_FINAL\Resources\Images\wellesley_sunset.jpg", UriKind.Relative));
                P_R1L_Label.Background = myBrush;

                String change = "<img src='images/wellesley_sunset.jpg' alt='Wellesley Sunset'></p>";
                generatedCode.Content = getHTML("Row 1, Left Element", change);
            }

            catch (Exception error)
            {
                Console.Out.Write(error);
            }
        }

         //Code for display the content after you "drop" it into its place - Row 1, Center Element
        private void OnDropTargetDrop2(object sender, SurfaceDragDropEventArgs e)
        {
            try
            {
                ImageBrush myBrush = new ImageBrush();
                BitmapImage bitmapImage = new BitmapImage();

                myBrush.ImageSource = new BitmapImage(new Uri(@"C:\Users\balichmac1\Desktop\WEBSEMBLY_FINAL\Resources\Images\wellesley_hooproll.jpg", UriKind.Relative));
                P_R1C_Label.Background = myBrush;

                String change = "<img src='images/wellesley_hooproll.jpg' alt='Hoop Rolling'></p>";
                generatedCode.Content = getHTML("Row 1, Center Element", change);
            }

            catch (Exception error)
            {
                Console.Out.Write(error);
            }
        }

         //Code for display the content after you "drop" it into its place - Row 1, Right Element
        private void OnDropTargetDrop3(object sender, SurfaceDragDropEventArgs e)
        {
            try
            {
                ImageBrush myBrush = new ImageBrush();
                BitmapImage bitmapImage = new BitmapImage();

                myBrush.ImageSource = new BitmapImage(new Uri(@"C:\Users\balichmac1\Desktop\WEBSEMBLY_FINAL\Resources\Images\wellesley_sci.jpg", UriKind.Relative));
                P_R1R_Label.Background = myBrush;

                String change = "<img src='images/wellesley_sci' alt='Science Center'></p>";
                generatedCode.Content = getHTML("Row 1, Right Element", change);
            }

            catch (Exception error)
            {
                Console.Out.Write(error);
            }
        }

        //Code for display the content after you "drop" it into its place - Row 2, Left Element
        private void OnDropTargetDrop4(object sender, SurfaceDragDropEventArgs e)
        {
            try
            {
                ImageBrush myBrush = new ImageBrush();
                BitmapImage bitmapImage = new BitmapImage();

                myBrush.ImageSource = new BitmapImage(new Uri(@"C:\Users\balichmac1\Desktop\WEBSEMBLY_FINAL\Resources\Videos\video1.jpg", UriKind.Relative));
                P_R2L_Label.Background = myBrush;

                String change = "<vid src='videos/hike.wmv' alt='Students Hiking'></p>";
                generatedCode.Content = getHTML("Row 2, Left Element", change);
            }

            catch (Exception error)
            {
                Console.Out.Write(error);
            }
        }

        //Code for display the content after you "drop" it into its place - Row 2, Center Element
        private void OnDropTargetDrop5(object sender, SurfaceDragDropEventArgs e)
        {
            try
            {
                ImageBrush myBrush = new ImageBrush();
                BitmapImage bitmapImage = new BitmapImage();

                myBrush.ImageSource = new BitmapImage(new Uri(@"C:\Users\balichmac1\Desktop\WEBSEMBLY_FINAL\Resources\Videos\video2.jpg", UriKind.Relative));
                P_R2C_Label.Background = myBrush;

                String change = "<vid src='videos/swimmers.wmv' alt='Swim Team'></p>";
                generatedCode.Content = getHTML("Row 2, Center Element", change);
            }

            catch (Exception error)
            {
                Console.Out.Write(error);
            }
        }

        //Code for display the content after you "drop" it into its place - Row 2, Right Element
        private void OnDropTargetDrop6(object sender, SurfaceDragDropEventArgs e)
        {
            try
            {
                ImageBrush myBrush = new ImageBrush();
                BitmapImage bitmapImage = new BitmapImage();

                myBrush.ImageSource = new BitmapImage(new Uri(@"C:\Users\balichmac1\Desktop\WEBSEMBLY_FINAL\Resources\Videos\video3.jpg", UriKind.Relative));
                P_R2R_Label.Background = myBrush;
                
                String change = "<vid src='videos/waban.wmv' alt='Waban Video'></p>";
                generatedCode.Content = getHTML("Row 2, Right Element", change);
            }

            catch (Exception error)
            {
                Console.Out.Write(error);
            }
        }

        //Code for Caption - Row 1, Left Element
        private void OnDropTargetDropCaption1(object sender, SurfaceDragDropEventArgs e)
        {
            try
            {
                ImageBrush myBrushCaption = new ImageBrush();
                BitmapImage bitmapImageCaption = new BitmapImage();
                myBrushCaption.ImageSource = new BitmapImage(new Uri(@"C:\Users\balichmac1\Desktop\WEBSEMBLY_FINAL\Resources\Icons\caption_R1L.jpg", UriKind.Relative));
            }

            catch (Exception error)
            {
                Console.Out.Write(error);
            }
        }
        
        //Code for Caption - Row 1, Center Element
        private void OnDropTargetDropCaption2(object sender, SurfaceDragDropEventArgs e)
        {
            try
            {
                ImageBrush myBrushCaption = new ImageBrush();
                BitmapImage bitmapImageCaption = new BitmapImage();
                myBrushCaption.ImageSource = new BitmapImage(new Uri(@"C:\Users\balichmac1\Desktop\WEBSEMBLY_FINAL\Resources\Icons\caption_R1C.jpg", UriKind.Relative));
            }

            catch (Exception error)
            {
                Console.Out.Write(error);
            }
        }

        //Code for Caption - Row 1, Right Element
        private void OnDropTargetDropCaption3(object sender, SurfaceDragDropEventArgs e)
        {
            try
            {
                ImageBrush myBrushCaption = new ImageBrush();
                BitmapImage bitmapImageCaption = new BitmapImage();
                myBrushCaption.ImageSource = new BitmapImage(new Uri(@"C:\Users\balichmac1\Desktop\WEBSEMBLY_FINAL\Resources\Icons\caption_R1R.jpg", UriKind.Relative));
            }

            catch (Exception error)
            {
                Console.Out.Write(error);
            }
        }

        //Code for Caption - Row 2, Left Element
        private void OnDropTargetDropCaption4(object sender, SurfaceDragDropEventArgs e)
        {
            try
            {
                ImageBrush myBrushCaption = new ImageBrush();
                BitmapImage bitmapImageCaption = new BitmapImage();
                myBrushCaption.ImageSource = new BitmapImage(new Uri(@"C:\Users\balichmac1\Desktop\WEBSEMBLY_FINAL\Resources\Icons\caption_R2L.jpg", UriKind.Relative));
            }

            catch (Exception error)
            {
                Console.Out.Write(error);
            }
        }

        //Code for Caption - Row 2, Center Element
        private void OnDropTargetDropCaption5(object sender, SurfaceDragDropEventArgs e)
        {
            try
            {
                ImageBrush myBrushCaption = new ImageBrush();
                BitmapImage bitmapImageCaption = new BitmapImage();
                myBrushCaption.ImageSource = new BitmapImage(new Uri(@"C:\Users\balichmac1\Desktop\WEBSEMBLY_FINAL\Resources\Icons\caption_R2C.jpg", UriKind.Relative));
            }

            catch (Exception error)
            {
                Console.Out.Write(error);
            }
        }

        //Code for Caption - Row 2, Right Element 
        private void OnDropTargetDropCaption6(object sender, SurfaceDragDropEventArgs e)
        {
            try
            {
                ImageBrush myBrushCaption = new ImageBrush();
                BitmapImage bitmapImageCaption = new BitmapImage();
                myBrushCaption.ImageSource = new BitmapImage(new Uri(@"C:\Users\balichmac1\Desktop\WEBSEMBLY_FINAL\Resources\Icons\caption_R2R.jpg", UriKind.Relative));
            }

            catch (Exception error)
            {
                Console.Out.Write(error);
            }
        }

        //Code for Title 
        private void OnDropTargetDropTitle(object sender, SurfaceDragDropEventArgs e)
        {
            try
            {
                ImageBrush myBrushCaption = new ImageBrush();
                BitmapImage bitmapImageCaption = new BitmapImage();
                myBrushCaption.ImageSource = new BitmapImage(new Uri(@"C:\Users\balichmac1\Desktop\WEBSEMBLY_FINAL\Resources\Icons\title.jpg", UriKind.Relative));
            }

            catch (Exception error)
            {
                Console.Out.Write(error);
            }
        }
       
        //Code to display text when Keydown in textareas for caption/title



        //When the user hits enter, swap the filler text with the user's inputted text for the title
        private void OnKeyDownHandlerTitle(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) //When the user hits enter
            {
                //Swap the filler text with the user's inputted text for the title
                generatedCode.Content = getHTML("Type Title Here", P_Cover_Label.Text);
            }
        }

        //When the user hits enter, swap the filler text with the user's inputted text for the top row, left caption
        private void OnKeyDownHandler1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) 
            {
                generatedCode.Content = getHTML("Row 1, Left Caption", "<p>"+CR1L_Label.Text);
            }
        }

        //When the user hits enter, swap the filler text with the user's inputted text for the top row, center caption
        private void OnKeyDownHandler2(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                generatedCode.Content = getHTML("Row 1, Center Caption", "<p>"+CR1C_Label.Text);
            }
        }

        //When the user hits enter, swap the filler text with the user's inputted text for the top row, right caption
        private void OnKeyDownHandler3(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                generatedCode.Content = getHTML("Row 1, Right Caption", "<p>"+CR1R_Label.Text);
            }
        }

        //When the user hits enter, swap the filler text with the user's inputted text for the bottom row, left caption
        private void OnKeyDownHandler4(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                generatedCode.Content = getHTML("Row 2, Left Caption", "<p>"+CR2L_Label.Text);
            }
        }

        //When the user hits enter, swap the filler text with the user's inputted text for the bottom row, center caption
        private void OnKeyDownHandler5(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                generatedCode.Content = getHTML("Row 2, Center Caption", "<p>"+CR2C_Label.Text);
            }
        }

        //When the user hits enter, swap the filler text with the user's inputted text for the bottom row, right caption
        private void OnKeyDownHandler6(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                generatedCode.Content = getHTML("Row 2, Right Caption", "<p>"+CR2R_Label.Text);
            }
        }

        //When the user enters a drop target with a dragged image, the image is dropped in the appropriate location
        private void OnDropTargetDragEnter(object sender, SurfaceDragDropEventArgs e)
        {
            PhotoData data = e.Cursor.Data as PhotoData;

            if (!data.CanDrop)
            {
                e.Effects = DragDropEffects.Move;
            }
        }

        // When the user drops a dragged item into the drop target, the cursor image changes from that image to default cursor
        private void OnTargetChanged(object sender, TargetChangedEventArgs e)
        {
            if (e.Cursor.CurrentTarget != null)
            {
                PhotoData data = e.Cursor.Data as PhotoData;
                e.Cursor.Visual.Tag = (data.CanDrop) ? "CanDrop" : "CannotDrop";
            }
            else
            {
                e.Cursor.Visual.Tag = null;
            }
        }

        // When the user initializes drag and drop functions, the cursor changes to reflect selected image
        private void Scatter_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement findSource = e.OriginalSource as FrameworkElement;
            ScatterViewItem draggedElement = null;

            //find the ScatterViewItem object that is being touched 
            while (draggedElement == null && findSource != null)
            {
                if ((draggedElement = findSource as ScatterViewItem) == null)
                {
                    findSource = VisualTreeHelper.GetParent(findSource) as FrameworkElement;
                }

            }
            if (draggedElement == null)
            {
                return;
            }
            PhotoData data = draggedElement.Content as PhotoData;
            ContentControl cursorVisual = new ContentControl()
            {
                Content = draggedElement.DataContext,
                Style = FindResource("CursorStyle") as Style
            };

            //create the list of input devices and the feducial markers 
            //add the touches that are currently captured within the dragged elt and
            //the current touch (if it isn't already in the list)
            List<InputDevice> devices = new List<InputDevice>();
            devices.Add(e.TouchDevice);
            foreach (TouchDevice touch in draggedElement.TouchesCapturedWithin)
            {
                if (touch != e.TouchDevice)
                {
                    devices.Add(touch);
                }
            }
            //get the drag source object
            ItemsControl dragSource = ItemsControl.ItemsControlFromItemContainer(draggedElement);

            //the scatterview object that the cursor is dragged out from
            SurfaceDragDrop.BeginDragDrop(
                dragSource, //the scatterview object that the cursor is dragged out from
                draggedElement, //the ScatterViewItem object that is dragged from the drag source
                cursorVisual, //the visual element of the cursor
                draggedElement.DataContext, //the data attached with the cursor
                devices, //the input devices that start dragging the cursor
                DragDropEffects.None); //the allowed drag-and-drop

            //this prevents the default touch operator from happening
            e.Handled = true;

            //hide the scatterviewitem for now. we will remove it if the dragdrop is successful
            draggedElement.Visibility = Visibility.Hidden; 
        }

        // Content Presenter is a mandatory WPF element used as a placeholder for XAML content that can insert content at runtime
        System.Windows.Controls.ContentPresenter FindContentPresenter(DependencyObject obj)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is System.Windows.Controls.ContentPresenter)
                {
                    return (System.Windows.Controls.ContentPresenter)child;
                }
                else
                {
                    System.Windows.Controls.ContentPresenter childOfChild =
                        FindContentPresenter(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
    }
}
