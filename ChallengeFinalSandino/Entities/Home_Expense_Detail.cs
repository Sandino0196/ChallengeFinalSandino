using System.ComponentModel.DataAnnotations;

namespace ChallengeFinalSandino.Entities
{
    public class Home_Expense_Detail
    {
        [Key]
        public int ID_Home_Expense { get; set; }
        public string ID_User { get; set; }
        public System.DateTime Date { get; set; }
        public double Spent_Money { get; set; }
    }
}
