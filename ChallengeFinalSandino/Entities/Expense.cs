using System.ComponentModel.DataAnnotations;

namespace ChallengeFinalSandino.Entities
{
    public class Expense
    {
        [Key]
        public int ID_Expense { get; set; }
        public string Description_Expense { get; set; }
    }
}
