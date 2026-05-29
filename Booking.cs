using System;

namespace EscapeRoomBookingSystem
{
    /// <summary>
    /// Booking model class - Represents a room booking entity
    /// </summary>
    public class Booking
    {
        public int BookingID { get; set; }
        public int RoomID { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public DateTime BookingDate { get; set; }
        public int GroupSize { get; set; }
        public string PaymentStatus { get; set; }
        public int? CompletionTime { get; set; }
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Booking() { }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        public Booking(int bookingID, int roomID, string customerName, string phone, DateTime bookingDate, int groupSize, string paymentStatus)
        {
            BookingID = bookingID;
            RoomID = roomID;
            CustomerName = customerName;
            Phone = phone;
            BookingDate = bookingDate;
            GroupSize = groupSize;
            PaymentStatus = paymentStatus;
            CompletionTime = null;
            CreatedDate = DateTime.Now;
        }

        /// <summary>
        /// Returns a string representation of the booking
        /// </summary>
        public override string ToString()
        {
            return $"Booking #{BookingID} - {CustomerName} ({GroupSize} people) on {BookingDate:g} - {PaymentStatus}";
        }
    }
}
