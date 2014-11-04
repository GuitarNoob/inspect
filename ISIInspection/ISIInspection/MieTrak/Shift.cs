//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ISIInspection.MieTrak
{
    using System;
    using System.Collections.Generic;
    
    public partial class Shift
    {
        public Shift()
        {
            this.BulletinMessages = new HashSet<BulletinMessage>();
            this.ShiftBreaks = new HashSet<ShiftBreak>();
            this.TimeCards = new HashSet<TimeCard>();
            this.TimeClockEntries = new HashSet<TimeClockEntry>();
            this.Users = new HashSet<User>();
        }
    
        public int ShiftPK { get; set; }
        public int DivisionFK { get; set; }
        public string Name { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public bool RequireOvertimeApproval { get; set; }
        public string MondayStartTime { get; set; }
        public string TuesdayStartTime { get; set; }
        public string WednesdayStartTime { get; set; }
        public string ThursdayStartTime { get; set; }
        public string FridayStartTime { get; set; }
        public string SaturdayStartTime { get; set; }
        public string SundayStartTime { get; set; }
        public string MondayEndTime { get; set; }
        public string TuesdayEndTime { get; set; }
        public string WednesdayEndTime { get; set; }
        public string ThursdayEndTime { get; set; }
        public string FridayEndTime { get; set; }
        public string SaturdayEndTime { get; set; }
        public string SundayEndTime { get; set; }
        public string MondayLunchOutTime { get; set; }
        public string TuesdayLunchOutTime { get; set; }
        public string WednesdayLunchOutTime { get; set; }
        public string ThursdayLunchOutTime { get; set; }
        public string FridayLunchOutTime { get; set; }
        public string SaturdayLunchOutTime { get; set; }
        public string SundayLunchOutTime { get; set; }
        public string MondayLunchInTime { get; set; }
        public string TuesdayLunchInTime { get; set; }
        public string WednesdayLunchInTime { get; set; }
        public string ThursdayLunchInTime { get; set; }
        public string FridayLunchInTime { get; set; }
        public string SaturdayLunchInTime { get; set; }
        public string SundayLunchInTime { get; set; }
        public decimal MondayOT1 { get; set; }
        public decimal TuesdayOT1 { get; set; }
        public decimal WednesdayOT1 { get; set; }
        public decimal ThursdayOT1 { get; set; }
        public decimal FridayOT1 { get; set; }
        public decimal SaturdayOT1 { get; set; }
        public decimal SundayOT1 { get; set; }
        public decimal MondayOT2 { get; set; }
        public decimal TuesdayOT2 { get; set; }
        public decimal WednesdayOT2 { get; set; }
        public decimal ThursdayOT2 { get; set; }
        public decimal FridayOT2 { get; set; }
        public decimal SaturdayOT2 { get; set; }
        public decimal SundayOT2 { get; set; }
        public decimal WeeklyOT1 { get; set; }
        public decimal WeeklyOT2 { get; set; }
        public Nullable<decimal> WeeklyOT3 { get; set; }
        public Nullable<decimal> DailyPlusShift { get; set; }
        public Nullable<decimal> DailyMinusShift { get; set; }
        public Nullable<decimal> DailyMaxPaidBreakTime { get; set; }
        public Nullable<decimal> DailyLunchLength { get; set; }
        public int DailyRoundUp { get; set; }
        public int DailyRoundDown { get; set; }
        public bool DailyForceInTimeToBeShiftTime { get; set; }
        public bool DailyScanLunch { get; set; }
        public Nullable<decimal> LunchAtHour { get; set; }
        public bool MondayOverTimeBeforeShift { get; set; }
        public bool TuesdayOverTimeBeforeShift { get; set; }
        public bool WednesdayOverTimeBeforeShift { get; set; }
        public bool ThursdayOverTimeBeforeShift { get; set; }
        public bool FridayOverTimeBeforeShift { get; set; }
        public bool SaturdayOverTimeBeforeShift { get; set; }
        public bool SundayOverTimeBeforeShift { get; set; }
        public bool MondayOverTimeAfterShift { get; set; }
        public bool TuesdayOverTimeAfterShift { get; set; }
        public bool WednesdayOverTimeAfterShift { get; set; }
        public bool ThursdayOverTimeAfterShift { get; set; }
        public bool FridayOverTimeAfterShift { get; set; }
        public bool SaturdayOverTimeAfterShift { get; set; }
        public bool SundayOverTimeAfterShift { get; set; }
        public decimal MondayOT3 { get; set; }
        public decimal TuesdayOT3 { get; set; }
        public decimal WednesdayOT3 { get; set; }
        public decimal ThursdayOT3 { get; set; }
        public decimal FridayOT3 { get; set; }
        public decimal SaturdayOT3 { get; set; }
        public decimal SundayOT3 { get; set; }
        public bool MondayOT1Enabled { get; set; }
        public bool MondayOT2Enabled { get; set; }
        public bool MondayOT3Enabled { get; set; }
        public bool TuesdayOT1Enabled { get; set; }
        public bool TuesdayOT2Enabled { get; set; }
        public bool TuesdayOT3Enabled { get; set; }
        public bool WednesdayOT1Enabled { get; set; }
        public bool WednesdayOT2Enabled { get; set; }
        public bool WednesdayOT3Enabled { get; set; }
        public bool ThursdayOT1Enabled { get; set; }
        public bool ThursdayOT2Enabled { get; set; }
        public bool ThursdayOT3Enabled { get; set; }
        public bool FridayOT1Enabled { get; set; }
        public bool FridayOT2Enabled { get; set; }
        public bool FridayOT3Enabled { get; set; }
        public bool SaturdayOT1Enabled { get; set; }
        public bool SaturdayOT2Enabled { get; set; }
        public bool SaturdayOT3Enabled { get; set; }
        public bool SundayOT1Enabled { get; set; }
        public bool SundayOT2Enabled { get; set; }
        public bool SundayOT3Enabled { get; set; }
        public bool WeeklyOT1Enabled { get; set; }
        public bool WeeklyOT2Enabled { get; set; }
        public bool WeeklyOT3Enabled { get; set; }
        public Nullable<bool> AllowClockInNonShiftDays { get; set; }
        public Nullable<int> MinuteAllowClockInPriorToShift { get; set; }
        public Nullable<bool> NoRoundingLunch { get; set; }
        public byte[] LastAccess { get; set; }
        public Nullable<bool> MondayNoLunch { get; set; }
        public Nullable<bool> TuesdayNoLunch { get; set; }
        public Nullable<bool> WednesdayNoLunch { get; set; }
        public Nullable<bool> ThursdayNoLunch { get; set; }
        public Nullable<bool> FridayNoLunch { get; set; }
        public Nullable<bool> SaturdayNoLunch { get; set; }
        public Nullable<bool> SundayNoLunch { get; set; }
    
        public virtual ICollection<BulletinMessage> BulletinMessages { get; set; }
        public virtual Division Division { get; set; }
        public virtual ICollection<ShiftBreak> ShiftBreaks { get; set; }
        public virtual ICollection<TimeCard> TimeCards { get; set; }
        public virtual ICollection<TimeClockEntry> TimeClockEntries { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
