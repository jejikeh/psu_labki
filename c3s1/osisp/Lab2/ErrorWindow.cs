using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace Lab2
{
    class ErrorWindow : Window
    {
        [UI] private Label _label1 = null;
        [UI] private Button _button1 = null;

        private int _counter;

        public ErrorWindow() : this(new Builder("ErrorWindow.glade")) { }

        private ErrorWindow(Builder builder) : base(builder.GetRawOwnedObject("ErrorWindow"))
        {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            _button1.Clicked += Button1_Clicked;
        }
        
        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private void Button1_Clicked(object sender, EventArgs a)
        {
            throw new Exception();
        }
    }
}
