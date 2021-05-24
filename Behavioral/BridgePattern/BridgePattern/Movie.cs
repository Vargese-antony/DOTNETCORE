using System;

namespace BridgePattern
{
    public class MovieLicense
    {
        private readonly Discount _discount;
        private readonly LicenseType _licenseType;
        public string Movie { get; }
        public DateTime PurchaseTime { get; }

        public MovieLicense(string movie, DateTime purchaseTime, Discount discount, LicenseType licenseType)
        {
            Movie = movie;
            PurchaseTime = purchaseTime;
            _discount = discount;
            _licenseType = licenseType;
        }
        public decimal GetPrice()
        {
            int discount = GetDiscount(_discount);
            decimal multiplier = 1 - discount / 100m;
            return GetBasePrice() * multiplier;

        }

        private int GetDiscount(Discount discount)
        {
            switch (discount)
            {
                case Discount.None:
                    return 0;
                case Discount.Military:
                    return 10;
                case Discount.Senior:
                    return 20;
                default:
                    return 0;    
            }
        }
        private decimal GetBasePrice()
        {
            switch (_licenseType)
            {
                case LicenseType.TwoDays:
                    return 4;
                case LicenseType.LifeLong:
                    return 8;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public DateTime? GetExpirationDate()
        {
            switch (_licenseType)
            {
                case LicenseType.TwoDays:
                    return PurchaseTime.AddDays(2);
                case LicenseType.LifeLong:
                    return null;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public enum Discount
    {
        None,
        Military,
        Senior
    }

    public enum LicenseType
    {
        TwoDays,
        LifeLong
    }

    //public class TwoDaysLicense : MovieLicense
    //{
    //    public TwoDaysLicense(string movie, DateTime purchaseTime, Discount discount)
    //        : base(movie, purchaseTime, discount)
    //    {
    //    }

    //    protected override decimal GetPriceCore()
    //    {
    //        return 4;
    //    }

    //    public override DateTime? GetExpirationDate()
    //    {
    //        return PurchaseTime.AddDays(2);
    //    }
    //}

    //public class LifeLongLicense : MovieLicense
    //{
    //    public LifeLongLicense(string movie, DateTime purchaseTime, Discount discount)
    //        : base(movie, purchaseTime, discount)
    //    {
    //    }

    //    protected override decimal GetPriceCore()
    //    {
    //        return 8;
    //    }

    //    public override DateTime? GetExpirationDate()
    //    {
    //        return null;
    //    }
    //}
}
