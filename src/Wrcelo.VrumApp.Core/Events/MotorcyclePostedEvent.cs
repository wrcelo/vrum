namespace Wrcelo.VrumApp.Core.Events
{
    public class MotorcyclePostedEvent
    {
        public Guid Guid { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public DateTime Date { get; set; }

        public MotorcyclePostedEvent() { }
        public MotorcyclePostedEvent(Guid id, string model, int year, DateTime date)
        {
            Guid = id;
            Model = model;
            Year = year;
            Date = date;
        }
    }
}
