﻿using System;
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
            Routing.RegisterRoute(nameof(PupilEntryPage), typeof(PupilEntryPage));
            Routing.RegisterRoute(nameof(GoalsPage), typeof(GoalsPage));
        }
    }
}
