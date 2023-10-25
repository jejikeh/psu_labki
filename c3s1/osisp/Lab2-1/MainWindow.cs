using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace Lab2_1
{
    class MainWindow : Window
    {
        [UI] private Label _label1 = null;
        [UI] private Button _button1 = null;
        [UI] private Button _button2 = null;
        [UI] private Button _button3 = null;
        
        private int _guessedNumber = 500;
        private int _shift = 500;
        
        private int _counter;

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);

            _label1.Text = $"Your number is {_guessedNumber}?";

            DeleteEvent += Window_DeleteEvent;
            _button1.Clicked += Button1_Clicked;
            _button2.Clicked += Button2_Clicked;
            _button3.Clicked += Button3_Clicked;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private void Button1_Clicked(object sender, EventArgs a)
        {
            _shift /= 2;
            if (_shift == 0) _shift = 1;
            _guessedNumber -= _shift;
            _label1.Text = $"Your number is {_guessedNumber}?";
        }
        
        private void Button2_Clicked(object sender, EventArgs a)
        {
            _shift /= 2;
            if (_shift == 0) _shift = 1;
            _guessedNumber += _shift;
            _label1.Text = $"Your number is {_guessedNumber}?";
        }
        
        private void Button3_Clicked(object sender, EventArgs a)
        {
            _label1.Text = "Yes! HORAYYY";
        }
    }
}
