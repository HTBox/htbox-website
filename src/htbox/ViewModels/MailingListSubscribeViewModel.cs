using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace htbox.ViewModels {
    public class MailingListSubscribeViewModel {
        [Required, DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required, DisplayName("Last Name")]
        public string LastName { get; set; }
        
        [Required, DisplayName("Email Address"), DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
    }
}