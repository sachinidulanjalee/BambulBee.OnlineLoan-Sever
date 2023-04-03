namespace BambulBee.OnlineLoan.COMMON
{
    public class ResponseMessages
    {
        #region Genaric

        public static string InsertSuccess { get { return "Record Successfully Inserted."; } }

        public static string UpdateSuccess { get { return "Record Successfully Updated."; } }

        public static string DeleteSuccess { get { return "Record Successfully Deleted."; } }

        public static string Failure { get { return "Something went wrong."; } }

        #endregion Genaric

        #region Leave Apply

        public static string AllLeaveAreUtilized { get { return "All Leaves are Utilized !"; } }

        public static string EntitlementNotGenerated { get { return "Entitlement not generated for the selected period !"; } }

        public static string DayTypeCodeNotdefined { get { return "Day type is not defined !"; } }

        public static string LeaveAllreadyApplyLeave { get { return "Already Applied Leave for given period !.."; } }

        public static string NotEnoughLeavebalance { get { return "Not enough leave balance this leave type !"; } }

        public static string NoOfOccurrence { get { return " Maximum no of occurrence are exceeded for the selected time period"; } }

        public static string ContinuouslyLeaveType { get { return "You cannot apply this particular leave type continuously !."; } }

        public static string IsRemarkRequired { get { return "Remark required selected leave type ! "; } }

        public static string HaveToApplyMinimum { get { return "You cannot exceed the minimum number of amount in leave type !."; } }

        public static string HaveToApplyMaximum { get { return "You cannot exceed the maximum number of amount in leave type "; } }

        public static string LeaveShouldApplyBefore { get { return "Leave should Apply Before "; } }

        public static string LeaveShouldApplyAfter { get { return "Leave should Apply After "; } }

        public static string CoveringEmployeeAllreadyApplyLeaveForGivenPeriod { get { return "Covering employee Already Applied Leave for given period !.."; } }

        public static string DocumentationRequired { get { return "Documentation required selected leave type ! "; } }

        public static string WorkingDaysValidation { get { return "Number of working days are zero ! "; } }

        public static string Successfullyapplied { get { return "Successfully applied !.."; } }

        #endregion Leave Apply
    }
}