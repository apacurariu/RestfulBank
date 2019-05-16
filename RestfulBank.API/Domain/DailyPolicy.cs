using System;
using System.Collections.Generic;
using System.Linq;

namespace RestfulBank.API.Domain
{
    public class DailyPolicy
    {
        public DailyPolicy()
        {
            Reservations = new List<Reservation>();
            DailyLimit = 5000;
        }

        public ICollection<Reservation> Reservations { get; private set; }
        public double DailyLimit { get; set; }

        private void CancelReservation(Reservation reservation)
        {
            Reservations.Remove(reservation);
        }

        public Reservation Reserve(double amount, DateTime now)
        {
            var reservationTotal = Reservations.Where(r => r.Timestamp.Date == now.Date).Sum(r => r.Amount);

            if (reservationTotal + amount <= DailyLimit)
            {
                var reservation = new Reservation(this, amount, now);

                Reservations.Add(reservation);

                return reservation;
            }
            else
            {
                return null;
            }
        }

        public class Reservation
        {
            public Reservation(DailyPolicy dailyPolicy, double amount, DateTime date)
            {
                DailyPolicy = dailyPolicy;
                Timestamp = date;
                Amount = amount;
            }

            public DailyPolicy DailyPolicy { get; }

            public DateTime Timestamp { get; private set; }
            public double Amount { get; private set; }

            public void Cancel()
            {
                DailyPolicy.CancelReservation(this);
            }
        }
    }


}
