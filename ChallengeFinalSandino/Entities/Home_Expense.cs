using System.ComponentModel.DataAnnotations;

namespace ChallengeFinalSandino.Entities
{
    public class Home_Expense
    {
        [Key]
        public int ID_Home_Expense { get; set; }
        public string Description_Expense { get; set; }
    }
}
