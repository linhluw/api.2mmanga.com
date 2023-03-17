using System;

namespace MyWeb.COM.Utilities
{
    public abstract class Converter
    {
        // Fields
        private readonly Guid _From;

        private readonly Guid _To;

        // Properties
        public Guid From { get { return _From; } }

        public Guid To { get { return _To; } }

        // Constructors
        internal Converter(Guid from, Guid to)
        {
            _From = from;
            _To = to;
        }

        // Functions
        public abstract object Convert(object obj);
    }

    public static class ConvertDateTime
    {
        /// <summary>
        /// Gets the date time from unixtime
        /// </summary>
        /// <param name="LastUpdate">The last update.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// GIANGLT  2/27/2019   created
        /// </Modified>
        public static DateTime? GetDateTimeFromunix(long? LastUpdate)
        {
            DateTime? date = null;

            if (LastUpdate != null)
            {
                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                date = start.AddMilliseconds(LastUpdate.Value).ToLocalTime();
            }

            return date;
        }

        public static string ConvertMinutesToHours(int? minutes)
        {
            string hours = "";

            if (minutes.HasValue)
            {
                var time = TimeSpan.FromMinutes(minutes.Value);
                hours = $"{(int)time.TotalHours:#00}:{time.ToString(@"mm\:ss")}";
            }
            return hours;
        }
    }
}
