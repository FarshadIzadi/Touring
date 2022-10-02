using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touring.Utility
{
    public static class SD
    {
        public const string RoleManager = "Manager";
        public const string RoleUser = "User";
        public const string RoleTourManager = "Tour Manager";
        public const string RoleTourGuide = "Tour Guide";
        public const string RoleFrontdesk = "Front Desk";
        public const string RoleAccountant = "Accountant";


        public const string TourStatusCreating = "Creating Tour in progress";
        public const string TourStatusPending = "Not Open for booking yet";
        public const string TourStatusBooking = "Open for booking";
        public const string TourStatusClosed = "Booking is not possible any longer";
        public const string TourStatusCancelled = "Tour Cancelled";
        public const string TourStatusAfoot = "Tour is going On";
        public const string TourStatusCompleted = "Tour Completed";
    }
}
