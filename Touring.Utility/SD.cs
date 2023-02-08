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

        public const string VisaStatusNotRequired = "Visa not required";
        public const string VisaStatusRequired = "Visa required";
        public const string VisaStatusApproved = "Visa Aproved";
        public const string VisaStatusRejected = "Visa Rejected";
        public const string VisaStatusWillExpire = "Visa Will Expire";

        public const string PassportStatusRequired = "Passport Required";
        public const string PassportStatusNotRequired = "Passport Not Required";
        public const string PassportStatusValid = "Passport Valid";
        public const string PassportStatusRenewal = "Passport Valid But Needs Renewal";
        public const string PassportStatusExpired = "Passport Expired";

        public const string BookingStatusPending = "Booking Pending";
        public const string BookingStatusBooked = "Booking Complete";
        public const string BookingStatusDocumentsMissing = "Documents needed";
        public const string BookingStatusPaymentPending = "Payment pending";

        public const string PaymentMethodStripe = "stripe";
        public const string PaymentMethodCash = "cash";
        public const string PaymentMethodLocal = "local";
        public const string PaymentMethodPos = "pos";
        public const string PaymentMethodCheque = "cheque";



    }
}
