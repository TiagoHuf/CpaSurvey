namespace Biopark.CpaSurvey.Domain.Entities;

public abstract class BaseEntity<TKeyType> 
{
    protected BaseEntity(TKeyType id = default)
    {
        Id = id;
    }

    public TKeyType Id { get; }
}