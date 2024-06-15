namespace Garage
{
    public readonly struct Owner
    {
        public string Name { get; }
        public string PhoneNumber { get; }

        public Owner(string i_Name, string i_PhoneNumber)
        {
            Name = i_Name;
            PhoneNumber = i_PhoneNumber;
        }

        public override string ToString() => string.Format(
            @"Owner name: {0}
Owner phone: {1}",
            Name,
            PhoneNumber);
    }
}