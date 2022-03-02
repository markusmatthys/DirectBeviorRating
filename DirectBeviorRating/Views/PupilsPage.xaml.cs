using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using System.Linq;
using DirectBeviorRating.Model;

namespace DirectBeviorRating.Views
{
    public partial class PupilsPage : ContentPage
    { 

        public PupilsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Retrieve all the notes from the database, and set them as the
            // data source for the CollectionView.
            collectionView.ItemsSource = await App.Database.GetPupilsAsync();

        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            // Navigate to the PupilEntryPage.
            await Shell.Current.GoToAsync(nameof(PupilEntryPage));
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the PupilEntryPage, passing the ID as a query parameter.
                Pupil pupil = (Pupil)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(PupilEntryPage)}?{nameof(PupilEntryPage.ItemId)}={pupil.ID.ToString()}");
            }
        }

        void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            Console.WriteLine("Toolbar Item Clicked");
        }

        void collectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
        }
    }
}
