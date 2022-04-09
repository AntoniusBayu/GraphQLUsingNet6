using RepoDb.Attributes;

namespace DataAccess
{
    /// <summary>
    /// Record Book itu lebih baik untuk encapsulation data.
    /// Bisa gunakan with expression in case mau nyelipin nilai untuk property baru
    /// Sekarang ada default value, sebenernya gak yg gimana gimana, kita kayak bisa set default value di property nya langsung
    /// </summary>
    [Map("Book")]
    public record Book
    {
        [Primary]
        public int AutoID { get; init; } = default; /*Defaultnya 0*/
        public string? Description { get; init; } = default(string?);  /*Defaultnya bisa nullable*/
        public DateTime? CreatedDate { get; init; } = default(DateTime?);  /*Defaultnya bisa nullable*/
        public bool IsActive { get; init; } = default;  /*Defaultnya false*/
        
        /// <summary>
        /// Overide function bawaan tostring
        /// Pake expresion buat pengganti kurung kurawal jadi lebih simple
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{Description} value";
    }
}
