//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KhasyanovRijakov418
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product_in_Storage
    {
        public int QuantityProduct_in_Storage { get; set; }
        public Nullable<int> StorageID { get; set; }
        public Nullable<int> ProductID { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Storages Storages { get; set; }
    }
}
