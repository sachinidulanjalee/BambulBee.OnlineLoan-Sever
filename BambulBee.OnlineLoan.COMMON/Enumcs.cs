using System.ComponentModel;

namespace BambulBee.OnlineLoan.COMMON
{
    public enum Test
    {
        [Description("DEMO")]
        DEMO = 1,
    }

    public enum LendingStatus
    {
        [Description("Issued")]
        NotApplicble = 0,

        [Description("Damaged")]
        Damaged = 1,

        [Description("Misplaced")]
        Missplased = 2,

        [Description("Collected")]
        Collected = 3
    }
    public enum UserStatus
    {
        [Description("New User")]
        NewUser = 1,

        [Description("Active")]
        Active = 2,

        [Description("Password Reset")]
        PasswordReset = 3,

        [Description("Auto Inactive")]
        AutoInactive = 4,

        [Description("Inactive")]
        Inactive = 5
    }

    public enum AvalaibleStatus
    {
        [Description("Available")]
        Avalaible = 1,

        [Description("Not-Available")]
        NotAvaliable = 2,

        [Description("Lended")]
        Lended = 3,

        [Description("Reference Only")]
        ReferenceOnly = 4,
    }
    public enum Status
    {
        Active = 1,
        Inactive = 2
    }

    public enum sex
    {
        Male = 1,
        Female = 2,
        Other
    }

}