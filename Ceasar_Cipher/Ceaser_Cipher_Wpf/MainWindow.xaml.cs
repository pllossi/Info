using System;
using System.Collections.Generic;
using System.Windows;
using Ceasar_Cipher;

namespace Ceaser_Cipher_Wpf
{
    public partial class MainWindow : Window
    {
        private Cipher _cipher;
        private List<string> _encryptions;
        private List<string> _decryptions;
        private string _lastDecryption;
        private int _lastShift;

        public MainWindow()
        {
            InitializeComponent();
            _cipher = new Cipher();
            _encryptions = new List<string>();
            _decryptions = new List<string>();
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtShift.Text, out int shift))
            {
                string inputText = txtInput.Text;
                string encryptedText = _cipher.Enrc(inputText, shift);
                OutputTextBlock.Text = encryptedText;
                AddToList(_encryptions, encryptedText, EncryptionsListBox);
                _lastDecryption = encryptedText;
                _lastShift = shift;
                Decript_Last.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Per favore, inserisci un valore di shift valido.");
            }
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtShift.Text, out int shift))
            {
                string inputText = txtInput.Text;
                string decryptedText = _cipher.Decrypt(inputText, shift);
                OutputTextBlock.Text = decryptedText;
                AddToList(_decryptions, decryptedText, DecryptionsListBox);
            }
            else
            {
                MessageBox.Show("Per favore, inserisci un valore di shift valido.");
            }
        }

        private void AddToList(List<string> list, string text, System.Windows.Controls.ListBox listBox)
        {
            if (list.Count >= 5)
            {
                list.RemoveAt(0);
            }
            list.Add(text);
            listBox.ItemsSource = null;
            listBox.ItemsSource = list;
        }

        private void txtShift_GotFocus(object sender, RoutedEventArgs e)
        {
            txtShift.Text = "";
        }

        private void txtInput_GotFocus(object sender, RoutedEventArgs e)
        {
            txtInput.Text = "";
        }

        private void Decript_Last_Click(object sender, RoutedEventArgs e)
        {
            if (_lastDecryption != null && _lastShift != 0)
            {
                string decryptedText = _cipher.Decrypt(_lastDecryption, _lastShift);
                OutputTextBlock.Text = decryptedText;
                AddToList(_decryptions, decryptedText, DecryptionsListBox);
            }
            else
            {
                MessageBox.Show("Nessuna decriptazione precedente disponibile.");
            }

        }
    }
}
