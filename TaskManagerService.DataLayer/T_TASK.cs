//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaskManagerService.DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_TASK
    {
        public int TASK_ID { get; set; }
        public Nullable<int> PARENT_ID { get; set; }
        public string TASK { get; set; }
        public System.DateTime START_DT { get; set; }
        public System.DateTime END_DT { get; set; }
        public int PRIORITY { get; set; }
        public System.DateTime CRT_DT { get; set; }
        public string CRT_BY { get; set; }
        public Nullable<System.DateTime> UPDT_DT { get; set; }
        public string UPDT_BY { get; set; }
        public string ACT_IND { get; set; }
    }
}
