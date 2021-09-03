using SynetecAssessmentApi.Domain.Interfaces;

namespace SynetecAssessmentApi.Domain
{
    public class Entity : IBaseEntity
    {
        public int Id { get; set; }
        
        public Entity(int id)
        {
            Id = id;
        }
    }
}