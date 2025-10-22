using Domain.Entities;
using System;
using System.Windows;
using Application;

namespace GattileUI
{
    /// <summary>
    /// Interaction logic for CatDetailsWindow.xaml
    /// </summary>
    public partial class CatDetailsWindow : Window
    {
        public CatDetailsWindow(Cat cat)
        {
            InitializeComponent();
            DataContext = new CatDetailsViewModel(cat);
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

    public class CatDetailsViewModel
    {
        public string Name { get; }
        public string Breed { get; }
        public string Gender { get; }
        public DateTime? BirthDate { get; }
        public string? Description { get; }
        public string IdentificationCode { get; }

        public CatDetailsViewModel(Cat cat)
        {
            Name = cat.Name;
            Breed = cat.Breed;
            Gender = cat.Male ? "Male" : "Female";
            BirthDate = cat.BirthDate;
            Description = cat.Description;
            IdentificationCode = cat.CodeId;
        }
    }
}
