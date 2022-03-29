using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;
using DirectBeviorRating.Model;

namespace DirectBeviorRating.Views
{
    [QueryProperty(nameof(pupilIdAsString), nameof(pupilIdAsString))]
    public partial class FocusPage : ContentPage
    {
        public string pupilIdAsString { get; set; }

        public FocusPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Retrieve the focus from a pupil from the database, and set them as the
            // data source for the CollectionView.
            int pupilIdAsInt = Convert.ToInt32(pupilIdAsString);
            collectionView.ItemsSource = await App.FocusDatabase.GetFocusesAsync(pupilIdAsInt);

        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            // Navigate to the PupilEntryPage.
            await Shell.Current.GoToAsync($"{nameof(FocusEntryPage)}?{nameof(FocusEntryPage.PupilIdAsString)}={pupilIdAsString}");
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the FocusEntryPage, passing the ID as a query parameter.
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

