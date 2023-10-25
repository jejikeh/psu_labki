using System;
using System.IO;
using BigGustave;
using Gdk;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;
using Window = Gtk.Window;

namespace DopZadanie
{
    class MainWindow : Window
    {
        [UI] private DrawingArea _drawingArea = null;
        
        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);
            
            _drawingArea.Drawn += DrawingAreaOnDrawn;
            _drawingArea.SetSizeRequest(640, 480);
            
            DeleteEvent += Window_DeleteEvent;
        }

        private void DrawingAreaOnDrawn(object o, DrawnArgs args)
        {
            var shift_x = 0;
            var shift_y = 0;
            for (var i = 1; i <= 6; i++)
            {
                using var stream = File.OpenRead($"../../../{Random.Shared.Next(1, 6)}.png");
                var image = Png.Open(stream);

                for (var x = 0; x < image.Width; x++)
                {
                    for (var y = 0; y < image.Height; y++)
                    {
                        args.Cr.Rectangle(x + shift_x, y + shift_y, 1, 1);
                        args.Cr.SetSourceRGB((double)image.GetPixel(x, y).R / 255, (double)image.GetPixel(x, y).G / 255, (double)image.GetPixel(x, y).B /255);
                        args.Cr.Fill();

                    }
                }
                

                
                shift_x += 64;

                if (i % 2 == 0)
                {
                    shift_y += 64;
                    shift_x = 0;
                }
            }
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }
    }
}
