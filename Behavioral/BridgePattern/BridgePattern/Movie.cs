using System;

namespace BridgePattern
{
    public abstract class MovieLicense
    {
        private readonly Discount _discount;
        public string Movie { get; }
        public DateTime PurchaseTime { get; }

        protected MovieLicense(string movie, DateTime purchaseTime, Discount discount)
        {
            Movie = movie;
            PurchaseTime = purchaseTime;
            _discount = discount;
        }
        public decimal GetPrice()
        {
            int discount = _discount.GetDiscount();
            decimal multiplier = 1 - discount / 100m;
            return GetPriceCore() * multiplier;

        }
        protected abstract decimal GetPriceCore();
        public abstract DateTime? GetExpirationDate();
    }

    public class TwoDaysLicense : MovieLicense
    {
        public TwoDaysLicense(string movie, DateTime purchaseTime, Discount discount)
            : base(movie, purchaseTime, discount)
        {
        }

        protected override decimal GetPriceCore()
        {
            return 4;
        }

        public override DateTime? GetExpirationDate()
        {
            return PurchaseTime.AddDays(2);
        }
    }

    public class LifeLongLicense : MovieLicense
    {
        public LifeLongLicense(string movie, DateTime purchaseTime, Discount discount)
            : base(movie, purchaseTime, discount)
        {
        }

        protected override decimal GetPriceCore()
        {
            return 8;
        }

        public override DateTime? GetExpirationDate()
        {
            return null;
        }
    }
}
