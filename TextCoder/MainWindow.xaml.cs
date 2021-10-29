using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var pair = new CharacterPair();
            pair.PairDeleted += Pair_PairDeleted;
            CharStack.Children.Add(pair);
        }

        private void Pair_PairDeleted(object? sender, EventArgs e)
        {
            CharStack.Children.Remove(sender as CharacterPair);
        }

        byte[] bytes;
        public string FileName { get; set; }

        private void FileSelectButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                //    FileContentTextBlock.Text = File.ReadAllText(openFileDialog.FileName);
                bytes = File.ReadAllBytes(openFileDialog.FileName);

                StringBuilder sb = new();
                for (int i = 0; i < bytes.Length; i++)
                {
                    byte b = bytes[i];
                    if (bytes[i] == 205) bytes[i] = 95;

                    sb.Append(b);
                    sb.Append(' ');
                }
                FileContentTextBlock.Text = sb.ToString();
                File.WriteAllBytes(openFileDialog.FileName + ".new.txt", bytes);
            }
        }

        private void RapleceCharactersButton_Click(object sender, RoutedEventArgs e)
        {
            byte[] newBytes = bytes.ToArray();   

            for (int i = 0; i < newBytes.Length;i++)
            {
                if (newBytes[i] == 95)
                    newBytes[i] = 105;
            }
            string decodedFileName = FileName + "decoded.txt";
            File.WriteAllBytes(decodedFileName, newBytes);
            DecodedContentTextBlock.Text = File.ReadAllText(decodedFileName);
        }
    }
}
