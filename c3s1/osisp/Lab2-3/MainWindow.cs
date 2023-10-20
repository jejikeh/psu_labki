using System;
using Gtk;
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
            _myProgressBar.

            DeleteEvent += Window_DeleteEvent;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }
    }
}
