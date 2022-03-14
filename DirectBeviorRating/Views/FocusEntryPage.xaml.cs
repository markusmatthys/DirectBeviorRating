using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using DirectBeviorRating.Model;

namespace DirectBeviorRating.Views
{
    //[QueryProperty(nameof(pupilIdAsString), nameof(pupilIdAsString))]
    public partial class FocusEntryPage : ContentPage
    {
        public string pupilIdAsString { get; set; }

        public FocusEntryPage()
        {
            InitializeComponent();
            Focus aFocus = new Focus(pupilIdAsString: pupilIdAsString);
            BindingContext = aFocus;
        }

        async void OnSaveButtonClicked(System.Object sender, System.EventArgs e)
        {
            var focus = (Focus)BindingContext;
            focus.Date = DateTime.UtcNow;
            if (!string.IsNullOrWhiteSpace(focus.SpecificFocus))
            {
                await App.FocusDatabase.SaveFocusAsync(focus);
            }


            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            //var pupil = (Pupil)BindingContext;
            //await App.Database.DeletePupilAsync(pupil);

            //// Navigate backwards
            //await Shell.Current.GoToAsync("..");
        }

    }

}
