
namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rColorSlider.ValueChanged += RColorSlider_ValueChanged;
            gColorSlider.ValueChanged += GColorSlider_ValueChanged;
            bColorSlider.ValueChanged += BColorSlider_ValueChanged;

            colorBox.BackColorChanged += ColorBox_BackColorChanged;

            colorBox.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void ColorBox_BackColorChanged(object? sender, EventArgs e)
        {
            rHex.Text = ColorTranslator.ToHtml(colorBox.BackColor);
        }

        private void GColorSlider_ValueChanged(object? sender, EventArgs e)
        {
            gValue.Text = gColorSlider.Value.ToString();
            colorBox.BackColor = Color.FromArgb(colorBox.BackColor.R, gColorSlider.Value, colorBox.BackColor.B);
        }

        private void BColorSlider_ValueChanged(object? sender, EventArgs e)
        {
            bValue.Text = bColorSlider.Value.ToString();
            colorBox.BackColor = Color.FromArgb(colorBox.BackColor.R, colorBox.BackColor.G, bColorSlider.Value);



        }

        private void RColorSlider_ValueChanged(object? sender, EventArgs e)
        {
            rValue.Text = rColorSlider.Value.ToString();
            colorBox.BackColor = Color.FromArgb(rColorSlider.Value, colorBox.BackColor.G, colorBox.BackColor.B);
        }
    }
}