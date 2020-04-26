using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PilkarzeMVVM
{

    public partial class TextBox : UserControl
    {
        public string Text
        {
            get => textBox.Text;
            set => textBox.Text = value;
        }

        public Brush TextBoxBorderBrush
        {
            get => border.BorderBrush;
            set => border.BorderBrush = value;
        }

        private static Brush BrushForAll { get; set; } = Brushes.Red;
        public TextBox()
        {
            InitializeComponent();
            border.BorderBrush = BrushForAll;
        }
        public void SetError(string errorText)
        {
            textBlockToolTip.Text = errorText;

            if (errorText != "")
            {
                border.BorderThickness = new Thickness(1);
                toolTip.Visibility = Visibility.Visible;
            }
            else
            {
                border.BorderThickness = new Thickness(0);
                toolTip.Visibility = Visibility.Hidden;
            }
        }

        public void SetFocus()
        {
            textBox.Focus();
        }
    }
}