using System;
using System.Threading.Tasks;
using DirectBeviorRating.Model;
using Xamarin.Forms;

namespace DirectBeviorRating.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class PupilEntryPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadPupil(value);
            }
        }

        public PupilEntryPage()
        {
            InitializeComponent();

            // Set the BindingContext of the page to a new Pupil.
            BindingContext = new Pupil();
        }

        async void LoadPupil(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                // Retrieve the pupil and set it as BindingContext of the page.
                Pupil pupil = await App.PupilDatabase.GetPupilAsync(id);
                BindingContext = pupil;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load pupil.");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var pupil = (Pupil)BindingContext;
            pupil.Date = DateTime.UtcNow;
            if (!string.IsNullOrWhiteSpace(pupil.Name))
            {
                await App.PupilDatabase.SavePupilAsync(pupil);
            }

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var pupil = (Pupil)BindingContext;
            await App.PupilDatabase.DeletePupilAsync(pupil);

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

        async void OnFokusButtonClicked(object sender, EventArgs e)
        {
            var pupil = (Pupil)BindingContext;
            await Shell.Current.GoToAsync($"{nameof(FocusPage)}?{nameof(FocusPage.pupilIdAsString)}={pupil.ID.ToString()}");
        }
    }

   
}
