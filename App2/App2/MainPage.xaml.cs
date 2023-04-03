using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using static System.Net.WebRequestMethods;

namespace App2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var dataTemplate = new DataTemplate(() =>
            {
                var grid = new Grid();

                var columnDefinition = new ColumnDefinition();
                grid.ColumnDefinitions.Add(columnDefinition);

                columnDefinition = new ColumnDefinition();
                columnDefinition.Width = 20;
                grid.ColumnDefinitions.Add(columnDefinition);

                var nameLabel = new Label
                {
                    FontAttributes = FontAttributes.Bold,
                    VerticalTextAlignment = TextAlignment.Center
                };
                nameLabel.SetBinding(Label.TextProperty, ".");
                nameLabel.SetValue(Grid.ColumnProperty, 0);


                grid.Children.Add(nameLabel);

                var imageDelete = new Image
                {
                    Source = "delete.png",
                    WidthRequest = 24
                };
                imageDelete.SetValue(Grid.ColumnProperty, 1);

                var tapGestureRecognizerHere = new TapGestureRecognizer();
                tapGestureRecognizerHere.Tapped += (s, e) => {
                    Console.WriteLine("deletete tapped");
                };
                imageDelete.GestureRecognizers.Add(tapGestureRecognizerHere);

                grid.Children.Add(imageDelete);


                var dragGestureRecognizer = new DragGestureRecognizer
                {
                    CanDrag = true,
                };
                dragGestureRecognizer.DragStarting += (s, e) =>
                {
                    Console.WriteLine("drag starting");
                };

                grid.GestureRecognizers.Add(dragGestureRecognizer);

                var dropGestureRecognizer = new DropGestureRecognizer
                {
                    AllowDrop = true
                };

                dropGestureRecognizer.DragOver += (s, e) =>
                {
                    Console.WriteLine("dragover");
                    grid.TranslateTo(10, 0);
                };

                dropGestureRecognizer.DragLeave += (s, e) =>
                {
                    Console.WriteLine("dragleave");
                    grid.TranslateTo(0, 0);
                };


                dropGestureRecognizer.Drop += (s, e) =>
                {
                    Console.WriteLine("drop");

                    grid.TranslateTo(0, 0);
                };

                grid.GestureRecognizers.Add(dropGestureRecognizer);

                return new ViewCell { View = grid };

            });

            listView.ItemTemplate = dataTemplate;

            List<string> items = new List<string>();
            items.Add("Item 1");
            items.Add("Item 2");
            items.Add("Item 3");
            items.Add("Item 4");
            items.Add("Item 5");
            items.Add("Item 6");

            listView.ItemsSource = items;
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Console.WriteLine("listView_ItemSelected");
        }

        private void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Console.WriteLine("listView_ItemTapped");
        }
    }
}
