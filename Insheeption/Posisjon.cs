//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Insheeption
{
    using System;
    using System.Collections.Generic;
    
    public partial class Posisjon
    {
        public int sauID { get; set; }
        public string tid { get; set; }
        public string flokkID { get; set; }
        public string breddegrad { get; set; }
        public string lengdegrad { get; set; }
    
        public virtual Sauer Sauer { get; set; }
    }
}