//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentManagementSystem.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentAttachments
    {
        public System.Guid AttachmentID { get; set; }
        public System.Guid StudentNumber { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public Nullable<System.DateTime> UploadedAt { get; set; }
    
        public virtual Students Students { get; set; }
    }
}
