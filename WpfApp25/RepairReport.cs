//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp25
{
    using System;
    using System.Collections.Generic;
    
    public partial class RepairReport
    {
        public int ReportID { get; set; }
        public Nullable<int> RequestID { get; set; }
        public Nullable<System.DateTime> CompletionDate { get; set; }
        public string WorkDescription { get; set; }
        public Nullable<decimal> TimeSpent { get; set; }
        public Nullable<decimal> Cost { get; set; }
    
        public virtual Request Request { get; set; }
    }
}
