using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using DirectBeviorRating.Model;

namespace DirectBeviorRating.Views
{
    [QueryProperty(nameof(PupilIdAsString), nameof(PupilIdAsString))]
    public partial class FocusEntryPage : ContentPage
    {


        public string PupilIdAsString {
            set {
                InitializeFocus(value);
            }
        }
        

        public FocusEntryPage()
        {
            InitializeComponent();
            BindingContext = new Focus();

        }
        public void InitializeFocus(string itemId)
        {
            try
            {
                int pupilId = Convert.ToInt32(itemId);
                // Retrieve the pupil and set it as BindingContext of the page.
                Focus focus = new Model.Focus();
                focus.PupilId = pupilId;
                BindingContext = focus;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to initialize focus.");
            }
        }

        async void OnSaveButtonClicked(System.Object sender, System.EventArgs e)
        {
            var focus = (Focus)BindingContext;
            focus.Date = DateTime.UtcNow;
            string PupilAsString = focus.PupilId.ToString();
            if (!string.IsNullOrWhiteSpace(focus.SpecificFocus))
            {
                await App.FocusDatabase.SaveFocusAsync(focus);
            }


            // Navigate backwards
            await Shell.Current.GoToAsync($"{("FocusPage")}?{nameof(FocusPage.pupilIdAsString)}={PupilAsString}");
            //await Shell.Current.GoToAsync("FocusPage");
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
