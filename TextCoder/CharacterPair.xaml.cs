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

namespace TextCoder
{
    /// <summary>
    /// Interaction logic for CharacterPair.xaml
    /// </summary>
    public partial class CharacterPair : UserControl
    {
        private string? _character1;
        private string? _character2;
        public string Character1 { get { return _character1??string.Empty; } set { _character1 = value; Char1.Text = _character1; } }
        public string Character2 { get { return _character2??string.Empty; } set { _character2 = value; Char2.Text = _character2; } }

        public event EventHandler? PairDeleted;

        public CharacterPair()
        {
            InitializeComponent();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            PairDeleted?.Invoke(this, EventArgs.Empty);
        }

        private void Char1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Character1 = (sender as TextBox)?.Text??String.Empty;            
        }

        private void Char2_TextChanged(object sender, TextChangedEventArgs e)
        {
            Character2 = (sender as TextBox)?.Text ?? String.Empty;
        }
    }
}
