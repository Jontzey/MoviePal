using MoviePal.Data;
using MoviePal.Models;
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

namespace MoviePal
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

        private void btnDirector_Click(object sender, RoutedEventArgs e)
        {
            using (AppDbContext Context = new AppDbContext())
            {
                director Newdirector = new();

                Newdirector.Firstname = txtDirectorFirstName.Text;
                Newdirector.LastName = txtDirectorLastName.Text;

                Context.Directors.Add(Newdirector);
                Context.SaveChanges();
            }
        }

        private void btnAddActor_Click(object sender, RoutedEventArgs e)
        {
            using (AppDbContext context = new())
            {
                context.Actors.Add(new actor()
                {
                    FirstName = txtActorFirstName.Text,
                    LastName = txtActorLastName.Text,
                });
                context.SaveChanges();
            }
        }
    }
}
