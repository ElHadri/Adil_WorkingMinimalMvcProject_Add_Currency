using DomainLogic.Interfaces;

using System;

namespace UI_MVC.Core
{
    public class TimeProvider: ITimeProvider
    {
        private static ITimeProvider current = new DefaultTimeProvider();
        public static ITimeProvider Current
        {
            get { return current; }
            set { current = value; }
        }

        public DateTime Now => throw new NotImplementedException(); // to do...
         
        private class DefaultTimeProvider : ITimeProvider
        {
            public DateTime Now { get { return DateTime.Now; } }
        }
    }
}
