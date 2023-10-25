using System;
using Gtk;
using Pango;
using UI = Gtk.Builder.ObjectAttribute;

namespace Lab2_3
{
    class MainWindow : Window
    {
        [UI] private Label _label1 = null;
        [UI] private ProgressBar _myProgressBar = null;

        private int _counter;

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);
            
            _label1.Text = "Installing Software...";

            DeleteEvent += Window_DeleteEvent;
            _myProgressBar.Text = "Hello, Im a progress bar!";
            _myProgressBar.Ellipsize = EllipsizeMode.Start;
            
            Drawn += OnDrawn;
        }

        private static int _countTimer = 0;
        private static int _desireCount = Random.Shared.Next(100, 1000);
        private static bool isDone = false;
        
        private void OnDrawn(object o, DrawnArgs args)
        {
            if (_countTimer % 10 == 0 && !isDone)
            {
                _myProgressBar.Pulse();
                _myProgressBar.Text = $"{((float)_countTimer / _desireCount) * 100}% is done!";
            }
            
            if (_countTimer == _desireCount)
            {
                _myProgressBar.Text = "Done!";
                _label1.Text = "Done!";
                isDone = true;
            }
            
            _countTimer++;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }
    }
}
