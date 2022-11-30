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

            using (AppDbContext context = new())
            {
                List<director> directors = context.Directors.ToList();

                // POpulate directors
                foreach (director director in directors)
                {
                    ComboBoxItem item = new ComboBoxItem();

                    item.Content = $"{director.Firstname} {director.LastName}";
                    item.Tag = director;
                    cbDirectors.Items.Add(item);
                }
                //populate actors
                List<actor> actors = context.Actors.ToList();

                foreach (actor actor in actors)
                {
                    ListViewItem item = new ListViewItem();

                    item.Content = $"{actor.FirstName} {actor.LastName}";
                    item.Tag = actor;

                    lvActors.Items.Add(item);
                }

                List<Movie> movies = context.Movies.ToList();

                foreach(Movie movie in movies)
                {
                    ComboBoxItem item = new ComboBoxItem();

                    item.Content = movie.Title;
                    item.Tag= movie;

                    cbMovies.Items.Add(item);

                }
            }
                
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

        private void btnAddMovie_Click(object sender, RoutedEventArgs e)
        {
            using (AppDbContext context = new())
            {
                Movie NewMovie = new Movie();

                NewMovie.Title = txtMovieTitle.Text;
                NewMovie.IsWatched = (bool)xbMovieWatched.IsChecked!;


                ComboBoxItem selectedItem = cbDirectors.SelectedItem as ComboBoxItem;
                director selectedDirector = selectedItem.Tag as director;

                director dbDirector = context.Directors.FirstOrDefault(d => d.DirectorId == selectedDirector.DirectorId);

                NewMovie.Director = dbDirector;

                context.Movies.Add(NewMovie);
                context.SaveChanges();
            }
        }
    }
}
