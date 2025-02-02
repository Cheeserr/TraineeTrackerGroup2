﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTrackerTests.lib
{
    public static class AppConfigReader
    {
        public static readonly string BaseUrl = ConfigurationManager.AppSettings["base_url"];
        public static readonly string LoginUrl = ConfigurationManager.AppSettings["login_url"];
        public static readonly string RegisterUrl = ConfigurationManager.AppSettings["register_url"];
        public static readonly string PrivacyUrl = ConfigurationManager.AppSettings["privacy_url"];
        public static readonly string UserUrl = ConfigurationManager.AppSettings["user_url"];
        public static readonly string ForgotPasswordUrl = ConfigurationManager.AppSettings["forgot_password_url"];
        public static readonly string TrackerIndexUrl = ConfigurationManager.AppSettings["tracker_index_url"];
        public static readonly string TrackerCreateUrl = ConfigurationManager.AppSettings["tracker_create_url"];
        public static readonly string TrackerDetailsUrl = ConfigurationManager.AppSettings["tracker_details_url"];
        public static readonly string TrackerDeleteUrl = ConfigurationManager.AppSettings["tracker_delete_url"];
        public static readonly string TrackerEditUrl = ConfigurationManager.AppSettings["tracker_edit_url"];
        public static readonly string UserCreateUrl = ConfigurationManager.AppSettings["user_create_url"];
        public static readonly string UserDeleteUrl = ConfigurationManager.AppSettings["user_delete_url"];
        public static readonly string UserDetailsUrl = ConfigurationManager.AppSettings["user_details_url"];
        public static readonly string UserEditUrl = ConfigurationManager.AppSettings["user_edit_url"];
        public static readonly string UserIndexUrl = ConfigurationManager.AppSettings["user_index_url"];
    }
}
