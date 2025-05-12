namespace shipment_track.src.Utils
{

    public enum ShipmentStatus
    {
        pending,
        confirmed,
        packed,
        inTransit,
        delivered,
        failed,

    }

    public enum CarrierSize
    {
        small,
        medium,
        large
    }

    public enum ShipmentEta
    {
        oneWeek,
        twoWeeks,
        threeWeeks
    }

    public static class ShipmentStatusValidator
    {
        public static bool CheckStatusValidity(string status)
        {
            if (
                status == "pending" ||
                status == "confirmed" ||
                status == "packed" ||
                status == "inTransit" ||
                status == "delivered" ||
                status == "failed"
            ) return true;

            return false;
        }

        public static ShipmentStatus getStatus(string status)
        {
            if (status == "failed")
                return ShipmentStatus.failed;

            if (status == "confirmed")
                return ShipmentStatus.confirmed;

            if (status == "packed")
                return ShipmentStatus.packed;

            if (status == "inTransit")
                return ShipmentStatus.inTransit;

            if (status == "delivered")
                return ShipmentStatus.delivered;

            return ShipmentStatus.pending;

        }

    }

    public static class CarrierVehicleValidator
    {
        public static bool CheckVehicleValidity(string vehicle)
        {
            if (
                vehicle == "small" ||
                vehicle == "medium" |
                vehicle == "large"
            ) return true;

            return false;
        }

        public static CarrierSize getSize(string vehicle)
        {

            if (vehicle == "medium")
                return CarrierSize.medium;

            if (vehicle == "large")
                return CarrierSize.large;

            return CarrierSize.small;

        }

        public static string GetSizeAsString(int vehicle)
        {

            if (vehicle == ((int)CarrierSize.large))
                return "large";

            if (vehicle == ((int)CarrierSize.medium))
                return "medium";

            return "large";

        }

    }

    public static class ShipmentEtaValidator
    {

        public static bool CheckEtaValidity(string eta)
        {
            if (
                eta == "one-week" ||
                eta == "two-weeks" |
                eta == "three-weeks"
            ) return true;

            return false;
        }

        public static ShipmentEta getEta(string eta)
        {

            if (eta == "two-weeks")
                return ShipmentEta.twoWeeks;

            if (eta == "three-weeks")
                return ShipmentEta.threeWeeks;

            return ShipmentEta.oneWeek;

        }

        public static string GetEtaAsString(int eta)
        {

            if (eta == ((int)ShipmentEta.threeWeeks))
                return "three-weeks";

            if (eta == ((int)ShipmentEta.twoWeeks))
                return "two-weeks";

            return "one-week";

        }

    }

    public static class ShipmentGenerator
    {
        public static decimal getPriceForShipment(Carrier carrier)
        {
            switch (CarrierVehicleValidator.GetSizeAsString((int)carrier.Vehicle))
            {
                case "small":
                    return 5;

                case "medium":
                    return 7;

                default:
                    return 10;

            }

        }

        public static string getReferenceForShipment()
        {

            char[] _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

            Random _random = new();

            var codeChars = _random.GetItems(_chars, 6);

            return new string(codeChars);

        }

    }

}