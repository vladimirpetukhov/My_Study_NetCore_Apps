using System.Collections.Generic;

namespace MUSACA.ViewModels.Users {
    public class UserReceiptsViewModel {
        public string Cashier { get; set; }
        public List<UserProfileViewModel> Receipts { get; set; }
    }
}
