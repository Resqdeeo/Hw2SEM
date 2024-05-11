using TeamHost.Common.Interfaces;

namespace TeamHost.Common;

public class BaseAuditableEntity : BaseEntity, IAuditableEntity
{
    /// <inheritdoc />
    public Guid? CreatedBy { get; set; }

    /// <inheritdoc />
    public DateTime? CreatedDate { get; set; }

    /// <inheritdoc />
    public Guid? UpdatedBy { get; set; }

    /// <inheritdoc />
    public DateTime? UpdatedDate { get; set; }
}