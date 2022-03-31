using System;
using System.Collections.Generic;
using DirectBeviorRating.Views;

using Xamarin.Forms;

namespace DirectBeviorRating
{
    public partial class ApplicationShell : Shell
    {
        public ApplicationShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("PupilPage", typeof(PupilsPage));
            Routing.RegisterRoute("PupilEntryPage", typeof(PupilEntryPage));
            Routing.RegisterRoute("FocusPage", typeof(FocusPage));
            Routing.RegisterRoute("FocusEntryPage", typeof(FocusEntryPage));
        }
    }

}
