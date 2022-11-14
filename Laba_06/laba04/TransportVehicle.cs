namespace laba05
{
    public abstract class TransportVehicle
    {
        public int CountPassengers;

        protected TransportVehicle(int countPassengers)
        {
            CountPassengers = countPassengers;
        }

        public override string ToString()
        {
            return $"this transport have {CountPassengers} count passengers";
        }
    }
}
