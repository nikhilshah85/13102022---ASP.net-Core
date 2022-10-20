namespace bankingAPI
{
    public class Accounts
    {
        public int accNo { get; set; }
        public string accName { get; set; }
        public string accType { get; set; }
        public double accBalance { get; set; }
        public bool accIsActive { get; set; }

        static List<Accounts> accList = new List<Accounts>()
        {
            new Accounts(){ accNo=101, accName="Nikhil", accBalance=5000, accIsActive=true, accType="Savings"},
            new Accounts(){ accNo=102, accName="Priya", accBalance=15000, accIsActive=true, accType="Current"},
            new Accounts(){ accNo=103, accName="Riya", accBalance=55000, accIsActive=false, accType="Savings"},
            new Accounts(){ accNo=104, accName="Jiya", accBalance=89000, accIsActive=true, accType="Savings"},
            new Accounts(){ accNo=105, accName="Diya", accBalance=155000, accIsActive=false, accType="Current"},
            new Accounts(){ accNo=106, accName="Aman", accBalance=500, accIsActive=true, accType="Savings"},
        };

        public List<Accounts> GetALlAccounts()
        {
            return accList;
        }
    }
}
